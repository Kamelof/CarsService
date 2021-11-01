using CarsCore.Models;
using CarsDataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task ConfirmEmailAsync(string email)
        {
            Email emailEntity = await GetEmailEntityAsync(email).FirstOrDefaultAsync();
            emailEntity.IsConfirmed = true;

            await _dbContext.SaveChangesAsync();
        }


        public async Task<string> GetConfirmMessageAsync(string email) => 
            await GetEmailEntityAsync(email)
            .Select(x => x.ConfirmationString)
            .FirstOrDefaultAsync();

        public async Task<int> RegisterEmailAsync(Email email)
        {
            _dbContext.Emails.Add(email);
            await _dbContext.SaveChangesAsync();

            return email.Id;
        }
        private IQueryable<Email> GetEmailEntityAsync(string email) =>
            _dbContext.Emails.Where(x => x.PostName == email);
    }
}
