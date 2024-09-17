namespace CarBiddingSite.Models.CarModels
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public CarBrand? Brand { get; set; }
        public CarModel? Model { get; set; }
        public ICollection<DamageRecord>? DamageRecords { get; set; }
        public decimal? Km { get; set; }
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
