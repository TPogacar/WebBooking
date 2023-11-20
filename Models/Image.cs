using System.Reflection.Metadata;

namespace WebBooking.Models
{
    public class Image
    {
        public int Id { get; set; }
        public Blob? Content { get; set; }
    }
}
