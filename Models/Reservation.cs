using System.ComponentModel;
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
        [DisplayName("Datum prihoda")]
        public DateOnly ArrivalDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Datum odhoda")]
        public DateOnly DepartureDate { get; set; }

        [ForeignKey(nameof(Room))]
        [Column(Order = 1)]
        [Required]
        [DisplayName("Izbira sobe")]
        public Room? BookedRoom { get; set; }

        [Required]
        [DisplayName("Ime in priimek")]
        public string? NameAndSurname { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string? EmailAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telefonska številka")]
        public string? PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Opomba / sporočilo")]
        public string? Footnote { get; set; }
    }
}
