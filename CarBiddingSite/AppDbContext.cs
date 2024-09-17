using CarBiddingSite.Models.CarModels;
using CarBiddingSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBiddingSite
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet properties for your models
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<DamageRecord> DamageRecords { get; set; }
        public DbSet<Listing> Listings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can configure your models here (optional)
            base.OnModelCreating(modelBuilder);
        }
    }
}
