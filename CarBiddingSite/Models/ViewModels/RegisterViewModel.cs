using System.ComponentModel.DataAnnotations;

namespace CarBiddingSite.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Username")]
        public string? UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Password")]
        public string? Password { get; set; }
    }
}
