using CarBiddingSite.Models.CarModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarBiddingSite.ViewModels
{
    public class CarBrandViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Car Brand Name")]
        public string ?Name { get; set; }

        public string? OriginCountry { get; set; }

        [Required(ErrorMessage = "Please provide Car Brand Model")]
        public List<CarModel> CarModels { get; set; }

        public int SelectedBrandId { get; set; }


        // Constructor to initialize lists
        public CarBrandViewModel()
        {
            CarModels = new List<CarModel>();
        }
    }
}
