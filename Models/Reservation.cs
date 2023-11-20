using System.ComponentModel.DataAnnotations;

namespace WebBooking.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [DataType(DataType.Date)] public DateOnly ArrivalDate { get; set; }
        [DataType(DataType.Date)] public DateTime DepartureDate { get; set; }
        public Room? BookedRoom { get; set; }
        [DataType(DataType.Text)] public string? NameAndSurname { get; set; }
        [DataType(DataType.EmailAddress)] public string? EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)] public string? PhoneNumber { get; set; }
        [DataType(DataType.MultilineText)] public string? Footnote { get; set; }
    }
}
