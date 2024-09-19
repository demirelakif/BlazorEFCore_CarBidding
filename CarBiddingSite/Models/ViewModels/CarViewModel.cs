using CarBiddingSite.Models.CarModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CarBiddingSite.Models.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide the year of the car")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please select a car brand")]
        public required CarBrand CarBrand { get; set; }

        public CarModel? Model { get; set; }

        public int Km { get; set; }

        [Required(ErrorMessage = "Please select a color")]
        public required Color SelectedColor { get; set; }

        public ICollection<DamageRecord>? DamageRecords { get; set; } // List of damage records

        // Constructor to initialize lists
        public CarViewModel()
        {
            DamageRecords = new List<DamageRecord>();
        }
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
