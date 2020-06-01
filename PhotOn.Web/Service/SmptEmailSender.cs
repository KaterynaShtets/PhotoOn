using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PhotOn.Web.Service
{
    public class SmptEmailSender : IEmailSender
    {
        private readonly IOptions<SmtpOptions> options;
        public SmptEmailSender(IOptions<SmtpOptions> options)
        {
            this.options = options;
        }
        public async Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message)
        {
            var mailMessage = new MailMessage(fromAddress, toAddress, subject, message);
            using (var client = new SmtpClient(options.Value.Host, options.Value.Port)
            {
                Credentials = new NetworkCredential(options.Value.Username, options.Value.Password)
            })
            {
                await client.SendMailAsync(mailMessage);

            }
        }
    }
}
