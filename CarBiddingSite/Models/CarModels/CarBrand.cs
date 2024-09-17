namespace CarBiddingSite.Models.CarModels
{
    public class CarBrand
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? OriginCountry { get; set; }
        public required List<CarModel> CarModels { get; set; }

    }
}
