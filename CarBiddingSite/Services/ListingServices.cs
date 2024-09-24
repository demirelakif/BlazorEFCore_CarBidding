using CarBiddingSite.Models;
using CarBiddingSite.Models.CarModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarBiddingSite.Services
{
    public class ListingServices
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public ListingServices(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Listing>> GetAllListingsAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Listings.ToListAsync();
        }

        public async Task<Listing?> GetListingById(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Listings.FirstOrDefaultAsync(l => l.Id == id);

        }

        public async Task<List<Listing>>? GetListingByUserId(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Listings.Where(l => l.UserId == id)
                .Include(l => l.Car)
                .ThenInclude(c => c.Brand)
                .Include(l => l.Car.Model)
                .Include(l => l.Offers)
                .ThenInclude(o => o.UserFrom)
                .Include(l => l.Car.DamageRecords)
                .ToListAsync();

        }

        public async Task MakeOfferAsync(Offer offer)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.Offers.AddAsync(offer);
            await context.SaveChangesAsync();
        }

        public async Task<Listing?> GetListingByIdNew(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Listings
                .Include(l => l.Car)            // Car'ı dahil ediyoruz
                .ThenInclude(c => c.Brand)      // Car'ın Brand'ini de dahil ediyoruz
                .Include(l => l.Car.Model) // Car'ın hasar kayıtlarını da dahil ediyoruz
                .Include(l => l.Car.DamageRecords) // Car'ın hasar kayıtlarını da dahil ediyoruz
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Listing>> GetAllListingNew()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Listings
            .Include(l => l.Car)            // Car'ı dahil ediyoruz
            .ThenInclude(c => c.Brand)      // Car'ın Brand'ini de dahil ediyoruz
            .Include(l => l.Car.Model) // Car'ın hasar kayıtlarını da dahil ediyoruz
            .Include(l => l.Car.DamageRecords) // Car'ın hasar kayıtlarını da dahil ediyoruz
            .ToListAsync();
        }

        public async Task AddListingAsync(Listing listing)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            Console.WriteLine("AddListing", listing.Price);
            await context.Listings.AddAsync(listing);
            await context.SaveChangesAsync();
        }
        public async Task DeleteListingById(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.Listings.Where(listing => listing.Id == id).ExecuteDeleteAsync();
        }
        public async Task<Listing?> UpdateListingAsync(Listing listing)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var selectedListing = await context.Listings.FirstOrDefaultAsync(l => l.Id == listing.Id);
            if (selectedListing != null)
            {
                selectedListing.Car = listing.Car;
                selectedListing.UpdatedDate = DateTime.Now;
                selectedListing.Description = listing.Description;
                selectedListing.Price = listing.Price;
                selectedListing.ImageUrl = listing.ImageUrl;
                selectedListing.Title = listing.Title;
                selectedListing.CarId = listing.CarId;
            }
            await context.SaveChangesAsync();
            return selectedListing;

        }
    }
}
