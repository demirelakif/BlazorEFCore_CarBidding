namespace CarBiddingSite.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public User? UserTo {  get; set; }
        public int UserToId { get; set; }
        public User? UserFrom { get; set; }
        public int UserFromId { get; set; }
        public decimal OfferPrice { get; set; }
        public Listing ?Listing { get; set; }
        public int? ListingId { get; set; }
        public string ?Description { get; set; }
    }
}
