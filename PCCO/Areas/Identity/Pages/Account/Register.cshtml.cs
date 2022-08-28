using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using PCCO.DataAccess;
using PCCO.Models;

namespace PCCO.Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly PCCOContext _context;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            PCCOContext context)
        {
            _userManager = userManager;
            _context = context;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "The {0} must be at max {1} characters long.")]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "The {0} must be at max {1} characters long.")]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "The {0} must be at max {1} characters long.")]
            [Display(Name = "Middle name")]
            public string MiddleName { get; set; }

            [DisplayName("Identification code")]
            [Required(ErrorMessage = "You must enter a value for this field!")]
            [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact number should have 10 digits")]
            [Range(1, 9999999999, ErrorMessage = "Identification code should not contain characters")]
            public string IdentificationCode { get; set; }

            [DisplayName("Workplace")]
            [Required(ErrorMessage = "You must enter a value for this field!")]
            public string Workplace { get; set; }

            [DisplayName("Work position")]
            [Required(ErrorMessage = "You must enter a value for this field!")]
            public string WorkPosition { get; set; }

            [DisplayName("Birthday")]
            [DataType(DataType.Date), Required(ErrorMessage = "You must enter a value for this field!")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
            public DateTime Birthday { get; set; }

            [DisplayName("Phone number")]
            [Required(ErrorMessage = "You must enter a value for this field!")]
            [RegularExpression(@"^(?:\+38)?(0[5-9][0-9]\d{7})$", ErrorMessage = "Phone number should be in format '+380XXXXXXXXX'")]
            public string PhoneNumber { get; set; }

            [DisplayName("User role")]
            public string? Role { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            });
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                if (_context.ApplicationUsers.Any(x => x.Email == Input.Email))
                {
                    ModelState.AddModelError(string.Empty, "User with such email already exists.");
                    return Page();
                }
                if (_context.ApplicationUsers.Any(x => x.IdentificationCode == Input.IdentificationCode))
                {
                    ModelState.AddModelError(string.Empty, "User with such identification code already exists.");
                    return Page();
                }
                if (_context.ApplicationUsers.Any(x => x.PhoneNumber == Input.PhoneNumber))
                {
                    ModelState.AddModelError(string.Empty, "User with such phone number already exists.");
                    return Page();
                }
                var user = CreateUser();

                string userName = string.Join(" ", Input.LastName, Input.FirstName, Input.MiddleName);
                await _userStore.SetUserNameAsync(user, userName, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                user.IdentificationCode = Input.IdentificationCode;
                user.Workplace = Input.Workplace;
                user.WorkPosition = Input.WorkPosition;
                user.Birthday = Input.Birthday;
                user.PhoneNumber = Input.PhoneNumber;
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (Input.Role == null)
                    {
                        await _userManager.AddToRoleAsync(user, "Registrator");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, Input.Role);
                    }
                    /*Claim claim = new("CreateAdministrators", "True");
                    await _userManager.AddClaimsAsync(user, new List<Claim>() { claim });*/
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href=\"{HtmlEncoder.Default.Encode(callbackUrl)}\">clicking here</a>.");
                    TempData["success"] = "New User Created Successfully";
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    return Redirect(string.Format("/Administrator/Home?lastName=&idCode={0}", user.IdentificationCode));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
