using CarsCore.Models;
using CarsCore.Models.CarModels;
using Microsoft.EntityFrameworkCore;

namespace CarsDataLayer
{
    public class EFCoreContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<AccountInfo> Users { get; set; }
        public DbSet<Email> Emails { get; set; }

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(product => product.Id);
            });

            modelBuilder.Entity<AccountInfo>()
                .OwnsOne(accountInfo => accountInfo.LoginInfo,
                navigationBuilder =>
                {
                    navigationBuilder.Property(loginInfo => loginInfo.Login)
                        .HasColumnName("Login");
                    navigationBuilder.Property(loginInfo => loginInfo.Password)
                        .HasColumnName("Password");
                });
        }
    }
}
