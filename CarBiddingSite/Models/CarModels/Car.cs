namespace CarBiddingSite.Models.CarModels
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int BrandId { get; set; }
        public CarBrand? Brand { get; set; }
        public int ModelId { get; set; }
        public CarModel? Model { get; set; }
        public ICollection<DamageRecord>? DamageRecords { get; set; }
        public int Km { get; set; }
        public Color? Color { get; set; }
    }


    public enum Color
    {
        Blue,
        Red,
        Green,
        Yellow,
        Black,
        White
    }

}
