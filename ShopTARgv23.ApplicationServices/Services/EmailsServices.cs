using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MimeKit;
using ShopTARgv23.Core.Dto;
using ShopTARgv23.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.ApplicationServices.Services
{
    public class EmailsServices : IEmailsServices
    {

        private readonly IConfiguration _config;

        public EmailsServices
            (
                IConfiguration config
            )

        {
            _config = config;
        }

        public async Task SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = dto.Body
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

        }


        public void SendEmailToken(EmailTokenDto dto, string token)
        {
            dto.Token = token;
            var email = new MimeMessage();

            _config.GetSection("EmailUserName").Value = "thecron57@gmail.com";
            _config.GetSection("EmailHost").Value = "smtp.gmail.com";
            _config.GetSection("EmailPassword").Value = "";

            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;

            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body,

            };

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();

            smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.SendAsync(email);
            smtp.DisconnectAsync(true);
        }
    }
}
