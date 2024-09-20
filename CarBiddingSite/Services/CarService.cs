using CarBiddingSite.Models.CarModels;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace CarBiddingSite.Services
{
    public class CarService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public event Func<string, Task> OnWarning;
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

        public async Task AddBrandAsync(CarBrand brand)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();

            var result = await context.CarBrands.Where(b => b.Name == brand.Name).FirstOrDefaultAsync();
            if (result is null)
            {
                context.CarBrands.Add(brand);
                await context.SaveChangesAsync();
                await OnWarning?.Invoke(brand.Name+" added successfully");
            }
            else
            {
                await OnWarning?.Invoke("Brand name is already exist!");
            }
            
        }

        public async Task DeleteBrandById(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.CarBrands.Where(brand => brand.Id == id).ExecuteDeleteAsync();
        }

        public async Task DeleteCarModelById(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.CarModels.Where(model => model.Id == id).ExecuteDeleteAsync();
        }

        public async Task AddModelAsync(CarModel carModel)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var result = await context.CarModels.Where(m => m.CarBrandId == carModel.CarBrandId && m.ModelName == carModel.ModelName).FirstOrDefaultAsync();
            if(result is null)
            {
                context.CarModels.Add(carModel);
                await context.SaveChangesAsync();
                await OnWarning?.Invoke(carModel.ModelName + " added successfully");
            }
            else
            {
                await OnWarning?.Invoke("Model name is already exist!");
            }
            

        }

        public async Task<Car?> GetCarById(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Cars.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Car> AddCarAsync(Car car)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();
            Console.WriteLine("Car Eklendi----------------------------------------");
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
