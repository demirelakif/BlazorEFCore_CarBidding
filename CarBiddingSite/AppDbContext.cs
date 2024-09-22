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
        modelBuilder.Entity<Car>()
            .HasOne(c => c.Brand)
            .WithMany(b => b.Cars)
            .HasForeignKey(c => c.BrandId)
            .OnDelete(DeleteBehavior.Restrict); // Brand silindiğinde ilişkili Cars silinmez

            // Car ve Model arasındaki ilişki
         modelBuilder.Entity<Car>()
             .HasOne(c => c.Model)
             .WithMany(m => m.Cars)
             .HasForeignKey(c => c.ModelId)
             .OnDelete(DeleteBehavior.Restrict); // Model silindiğinde ilişkili Cars silinmez

            modelBuilder.Entity<Car>()
                .HasMany(c=>c.DamageRecords)
                .WithOne(d=>d.Car)
                .HasForeignKey(d=>d.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Listing>()
                .HasOne(l => l.Car)
                .WithOne(c => c.Listing) // Car'ın yalnızca bir Listing'i olabilir
                .HasForeignKey<Car>(c=>c.ListingId)
                .OnDelete(DeleteBehavior.Cascade); // Listing silindiğinde ilişkili Car da silinir

            modelBuilder.Entity<User>()
                .HasMany(u => u.Listings)
                .WithOne(l=>l.User)
                .HasForeignKey(l=>l.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            


        }
    }
}
