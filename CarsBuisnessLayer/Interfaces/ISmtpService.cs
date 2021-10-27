using CarsBuisnessLayer.DTOs;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.Interfaces
{
    public interface ISmtpService
    {
        Task SendMassageAsync(MailDTO mailDTO);
    }
}