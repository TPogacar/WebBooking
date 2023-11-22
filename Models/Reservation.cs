using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBooking.Models
{
    public class Reservation
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly ArrivalDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DepartureDate { get; set; }

        [ForeignKey(nameof(Room))]
        [Column(Order = 1)]
        [Required]
        public Room? BookedRoom { get; set; }

        [Required]
        public string? NameAndSurname { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string? Footnote { get; set; }
    }
}
