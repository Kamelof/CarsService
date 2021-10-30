using CarsCore.Models;
using System.Threading.Tasks;

namespace CarsDataLayer.Interfaces
{
    public interface IEmailRepository
    {
        Task<int> RegisterEmailAsync(Email email);
    }
}
