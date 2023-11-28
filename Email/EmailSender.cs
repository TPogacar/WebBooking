using System;

using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Configuration;
using Org.BouncyCastle.Utilities.Net;

namespace WebBooking.Email
{
    public class EmailSender : IEmailSender
    {
        // not used
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com", // email sender provider
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("pogacar.tami@gmail.com", "gjij hceu tuwe lnuj")
            };

            return client.SendMailAsync("veliki.posiljalec.mailov@gmail.com", email, subject, htmlMessage);
        }

        public void SendEmail(string email, string subject, string body)
        {
            MailAddress fromAddress = new MailAddress("pogacar.tami@gmail.com", "Veleposestnik Hotelski");
            MailAddress toAddress = new MailAddress(email, "Lastnik Hotela");
            const string fromPassword = "gjij hceu tuwe lnuj";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}