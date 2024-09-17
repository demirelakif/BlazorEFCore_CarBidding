using CarBiddingSite.Models.CarModels;
using System.ComponentModel.DataAnnotations;

namespace CarBiddingSite.Models.ViewModels
{
    public class ListingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a title for the listing")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please provide a description for the listing")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please provide a price for the listing")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal? Price { get; set; }

        public string? ImageUrl { get; set; }

        public int? SelectedBrandId { get; set; }  // Brand ID for dropdown selection
        public int? SelectedModelId { get; set; }  // Model ID for dropdown selection
        public int? SelectedDamageRecordId { get; set; }  // Damage record ID for dropdown selection

        public DateTime? CreatedDate { get; set; }

        public Car Car { get; set; } = new Car();



        public ListingViewModel()
        {
            CreatedDate = DateTime.UtcNow;
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
}
