using CarsCore.Models;
using System.Threading.Tasks;

namespace CarsDataLayer.Interfaces
{
    public interface IEmailRepository
    {
        Task<int> RegisterEmailAsync(Email email);
        Task<string> GetConfirmMessageAsync(string email);
        Task ConfirmEmailAsync(string email);
    }
}
