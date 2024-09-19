namespace CarBiddingSite.Models.CarModels
{
    public class CarModel
    {
        public int Id { get; set; }
        public int CarBrandId { get; set; }
        public CarBrand ?CarBrand { get; set; }
        public string? ModelName { get; set; }
        public int HP { get; set; }
        public required ICollection<Car> Cars { get; set; }
    }
}
