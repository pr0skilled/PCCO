using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PCCO.DataAccess;
using PCCO.Models.Extensions;
using PCCO.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using PCCO.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PCCOContext>(options => options.UseSqlServer(
    builder.Configuration["Database:Connection:Default"]));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<PCCOContext>()
    .AddDefaultUI();
builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
});

builder.Services.AddAuthentication()
.AddGoogle(o =>
{
    o.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    o.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    o.Events.OnRemoteFailure = (context) =>
    {
        context.Response.Redirect("/User/Home/Index");
        context.HandleResponse();
        return Task.CompletedTask;
    };
})
.AddFacebook(o =>
{
    o.AppId = builder.Configuration["Authentication:Facebook:AppId"];
    o.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
    o.Events.OnRemoteFailure = (context) =>
    {
        context.Response.Redirect("/User/Home/Index");
        context.HandleResponse();
        return Task.CompletedTask;
    };
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSingleton<IEmailSender, EmailSender>();
builder.Services.AddCustomServices();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/User/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");

app.Run();