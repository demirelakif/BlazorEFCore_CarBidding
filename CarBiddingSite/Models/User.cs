using System.ComponentModel.DataAnnotations;

namespace CarBiddingSite.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string? Role { get; set; }
        public ICollection<Listing>? Listings { get; set; }
        public ICollection<Offer>? OffersFrom { get; set; }
        public ICollection<Offer>? OffersTo { get; set; }
    }
}
