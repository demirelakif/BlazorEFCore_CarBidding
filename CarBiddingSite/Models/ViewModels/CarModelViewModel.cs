using System.ComponentModel.DataAnnotations;

namespace CarBiddingSite.ViewModels
{
    public class CarModelViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Car Model Name")]
        public string? ModelName { get; set; }

        [Required(ErrorMessage = "Please provide a horsepower value")]
        [Range(1, 5000, ErrorMessage = "Please provide a horsepower value between 1 and 5000")]
        public int HP { get; set; }
    }
}
