using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebBooking.Models;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace WebBooking.ViewModels
{
    public class ReservationViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Prosim, izberite datum prihoda")]
        [DataType(DataType.Date)]
        [DateIsInTheFuture]
        [DisplayName("Datum prihoda")]
        public DateOnly ArrivalDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        [Required(ErrorMessage = "Prosim, Izberite datum odhoda")]
        [DataType(DataType.Date)]
        [DisplayName("Datum odhoda")]
        public DateOnly DepartureDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        [Required(ErrorMessage = "Prosim, izberite sobo")]
        [DisplayName("Izbira sobe")]
        public Room? SelectedRoom { get; set; }

        [Required(ErrorMessage = "Prosim, vnesite ime in priimek")]
        [DisplayName("Ime in priimek")]
        public string? NameAndSurname { get; set; }

        [Required(ErrorMessage = "Prosim, vnesite email")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "Prosim, vnesite telefonsko številko")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telefonska številka")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Prosimo, zaupajte nam Vaše želje")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Opomba / sporočilo")]
        public string? Footnote { get; set; }


        #region Validacije
        public class DateIsInTheFuture : ValidationAttribute
        {
            public override string FormatErrorMessage(string name)
            {
                return "Izbrani datum ne sme biti v preteklosti";
            }

            protected override ValidationResult IsValid(object? objValue, ValidationContext validationContext)
            {
                DateOnly dateValue = objValue as DateOnly? ?? new DateOnly();

                if (dateValue < DateOnly.FromDateTime(DateTime.Today))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
                return ValidationResult.Success;
            }
        }
        #endregion

        public IEnumerable<Room>? lstRooms { get; }
    }
}
