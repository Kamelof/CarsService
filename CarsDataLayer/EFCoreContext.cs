using CarsCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsDataLayer
{
    public class EFCoreContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<ColorDb> Colors { get; set; }
        public DbSet<CarBodyDb> CarBodies { get; set; }

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBodyDb>().ToTable("CarBodies");
            modelBuilder.Entity<ColorDb>().ToTable("Colors");
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(i => i.Id);
            });
        }
    }
}
