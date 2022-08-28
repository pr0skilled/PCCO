using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Mailjet.Client.TransactionalEmails;

namespace PCCO.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public MailJetOptions _mailJetOptions;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _mailJetOptions.ApiKey = _configuration["MailJet:ApiKey"];
            _mailJetOptions.SecretKey = _configuration["MailJet:SecretKey"];

            MailjetClient client = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey);
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource
            };

            var transactionalEmail = new TransactionalEmailBuilder()
                .WithFrom(new SendContact("pr0skilled@proton.me"))
                .WithSubject(subject)
                .WithHtmlPart(htmlMessage)
                .WithTo(new SendContact(email))
                .Build();

            await client.SendTransactionalEmailAsync(transactionalEmail);
        }
    }
}
