using System.Reflection.Metadata;

namespace WebBooking.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int PricePerNight { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public int? Images { get; set; }
    }
}
