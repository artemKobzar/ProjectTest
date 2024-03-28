using Microsoft.Extensions.Configuration;
using ProjectTest.Application.Contracts.MailSender;
using ProjectTest.Application.Models.MailSender;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectTest.MailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_configuration["EmailSettings:Key"]);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _configuration["EmailSettings:FromAddress"],
                Name = _configuration["EmailSettings:FromName"]
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);
            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
