using CarsBuisnessLayer.DTOs;
using CarsBuisnessLayer.Interfaces;
using CarsCore.Options;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly SmtpOptions _smptOptions;

        public SmtpService(IOptions<SmtpOptions> smptOptions)
        {
            _smptOptions = smptOptions.Value;
        }

        public async Task SendMessageAsync(MailDTO mailDTO)
        {
            SmtpClient SmtpClient = new()
            {
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(
                    _smptOptions.SenderMail,
                    _smptOptions.SenderPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            MailAddress fromMailAddress = new(_smptOptions.SenderMail, _smptOptions.SenderName);
            MailAddress toMailAddress = new(mailDTO.To);
            MailMessage mailMessage = new()
            {
                From = fromMailAddress,
                Subject = mailDTO.Subject,
                Body = mailDTO.Body
            };

            mailMessage.To.Add(toMailAddress);

            await SmtpClient.SendMailAsync(mailMessage);
        }
    }
}
