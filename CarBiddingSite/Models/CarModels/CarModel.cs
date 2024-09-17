namespace CarBiddingSite.Models.CarModels
{
    public class CarModel
    {
        public int Id { get; set; }
        public int CarBrandId { get; set; }
        public string? ModelName { get; set; }
        public int HP { get; set; }
    }
}
