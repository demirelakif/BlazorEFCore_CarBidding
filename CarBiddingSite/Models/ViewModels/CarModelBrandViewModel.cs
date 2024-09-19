using CarBiddingSite.Models.CarModels;
using System.ComponentModel.DataAnnotations;

namespace CarBiddingSite.Models.ViewModels
{
    public class CarModelBrandViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Car Brand Name")]
        public string? Name { get; set; }

        public string? OriginCountry { get; set; }

        [Required(ErrorMessage = "Please provide Car Brand Model")]
        public List<CarModel> ?CarModels { get; set; }

        // Constructor to initialize lists

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Car Model Name")]
        public string? ModelName { get; set; }

        [Required(ErrorMessage = "Please provide a horsepower value")]
        [Range(1, 5000, ErrorMessage = "Please provide a horsepower value between 1 and 5000")]
        public int HP { get; set; }
    }
}
