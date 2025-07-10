using CondoSphere.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace CondoSphere.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string toEmail, string subject, string content)
        {
            // Read all settings from configuration (appsettings + user secrets)
            var from = _configuration["MailSettings:From"];
            var smtp = _configuration["MailSettings:Smtp"];
            var port = int.Parse(_configuration["MailSettings:Port"]);
            var password = _configuration["MailSettings:Password"];

            var message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(toEmail));

            // Configure the SmtpClient for Gmail
            var client = new SmtpClient
            {
                Host = smtp,
                Port = port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            return client.SendMailAsync(message);
        }
    }
}