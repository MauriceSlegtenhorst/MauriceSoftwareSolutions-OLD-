using Microsoft.Extensions.Options;
using SharedDependencyInterfaces.Interfaces;
using SharedLibrary.Models.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class EmailSender : IEmailSender
    {
        public AuthMessageSenderOptions Options { get; }

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public Task SendEmailAsync(string toEmail, string subject, string message)
        {
            MailMessage mail = GetMailMessage(toEmail, subject, message,
                Options.DefaultSenderEmail, Options.DefaultSenderDisplayName, Options.UseHtml);

            SmtpClient client = GetSmtpClient(Options.Domain, Options.Port, Options.RequiresAuthentication,
                Options.UserName, Options.Key, Options.UseSsl);

            return client.SendMailAsync(mail);
        }

        private static MailMessage GetMailMessage(string toEmail, string subject, string message,
        string defaultSenderEmail, string defaultSenderDisplayName = null, bool useHtml = true)
        {
            MailAddress sender;

            if (string.IsNullOrEmpty(defaultSenderEmail))
            {
                throw new ArgumentException("No sender mail address was provided");
            }
            else
            {
                sender = !string.IsNullOrEmpty(defaultSenderDisplayName) ?
                    new MailAddress(defaultSenderEmail, defaultSenderDisplayName) : new MailAddress(defaultSenderEmail);
            }

            MailMessage mail = new MailMessage()
            {
                From = sender,
                Subject = subject,
                Body = message,
                IsBodyHtml = useHtml,
                BodyEncoding = Encoding.UTF8
            };
            mail.To.Add(toEmail);
            return mail;
        }

        private static SmtpClient GetSmtpClient(string host, int port, bool requiresAuthentication = true,
            string userName = null, string userKey = null, bool useSsl = true)
        {
            SmtpClient client = new SmtpClient();

            if (string.IsNullOrEmpty(host))
            {
                throw new ArgumentException("No domain was provided");
            }

            client.Host = host;

            if (port > -1)
            {
                client.Port = port;
            }

            client.UseDefaultCredentials = !requiresAuthentication;

            if (requiresAuthentication)
            {
                if (string.IsNullOrEmpty(userName))
                {
                    throw new ArgumentException("No user name was provided");
                }

                client.Credentials = new NetworkCredential(userName, userKey);
            }

            client.EnableSsl = useSsl;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            return client;
        }
    }
}
