using CarBiddingSite.Models.CarModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CarBiddingSite.Services
{
    public class CarService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public CarService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        public async Task<List<CarBrand>> GetAllCarBrandsAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.CarBrands.Include(b => b.CarModels).ToListAsync();
        }

        public async Task<List<CarModel>> GetCarModelsByBrandIdAsync(int brandId)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.CarModels.Where(m => m.CarBrandId == brandId).ToListAsync();
        }

        public async Task<List<DamageRecord>> GetAllDamageRecordsAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.DamageRecords.ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Cars.ToListAsync();
        }

        public async Task<Car?> GetCarById(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Cars.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Car> AddCarAsync(Car car)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            context.Cars.Add(car);
            await context.SaveChangesAsync();
            return car;
        }

        public async Task DeleteCarById(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.Cars.Where(car => car.Id == id).ExecuteDeleteAsync();
        }

        //    public async Task<Car?> UpdateCarAsync(Car car)
        //    {
        //        using var context = await _dbContextFactory.CreateDbContextAsync();
        //        var existingCar = context.Cars.Where(x => x.Id == car.Id).FirstOrDefault();
        //        if (existingCar != null)
        //        {
        //            existingCar.Year = car.Year;
        //            existingCar.Price = car.Price;
        //            existingCar.Description = car.Description;
        //            existingCar.ImageUrl = car.ImageUrl;
        //            existingCar.Title = car.Title;
        //            await context.SaveChangesAsync();
        //            return existingCar;
        //        }
        //        return null;
        //    }
        //}
    }
}
