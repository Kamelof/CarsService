using CarsBuisnessLayer.DTOs;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.Interfaces
{
    public interface ISmtpService
    {
        Task SendMessageAsync(MailDTO mailDTO);
    }
}