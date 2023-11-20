using System.Reflection.Metadata;

namespace WebBooking.Models
{
    public class RoomImage
    {
        public int Id { get; set; }
        public Image? Image1 { get; set; }
        public Image? Image2 { get; set; }
        public Image? Image3 { get; set; }
    }
}
