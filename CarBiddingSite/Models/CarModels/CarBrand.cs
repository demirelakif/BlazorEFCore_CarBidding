namespace CarBiddingSite.Models.CarModels
{
    public class CarBrand
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? OriginCountry { get; set; }
        public ICollection<CarModel> ?CarModels { get; set; }
        public ICollection<Car> ?Cars { get; set; }

    }
}
