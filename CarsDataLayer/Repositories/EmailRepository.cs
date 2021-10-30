using CarsCore.Models;
using CarsDataLayer.Interfaces;
using System.Threading.Tasks;

namespace CarsDataLayer.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EFCoreContext _dbContext;

        public EmailRepository (EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> RegisterEmailAsync(Email email)
        {
            _dbContext.Emails.Add(email);
            await _dbContext.SaveChangesAsync();

            return email.Id;
        }
    }
}
