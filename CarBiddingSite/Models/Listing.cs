using CarBiddingSite.Models.CarModels;

namespace CarBiddingSite.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserId { get; set; }
        public Car ?Car { get; set; }
        //public ICollection<Request>? Requests { get; set; }
        public User ?User { get; set; }



        public Listing()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }

}
