using CarBiddingSite.Models;
using CarBiddingSite.Models.CarModels;
using Microsoft.EntityFrameworkCore;

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
        public async Task AddListingAsync(Listing listing)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.Listings.AddAsync(listing);
            await context.SaveChangesAsync();
        }
        public async void DeleteListingById(int id)
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
            }
            await context.SaveChangesAsync();
            return selectedListing;

        }
    }
}
