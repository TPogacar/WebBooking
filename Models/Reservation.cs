using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebBooking.Controllers;

namespace WebBooking.Models
{
    public class Reservation : IValidatableObject
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

        private Room? _room;
        [Required(ErrorMessage = "Prosim, izberite sobo")]
        [DisplayName("Izbira sobe")]
        [BindProperty]
        public int RoomId
        {
            get
            {
                if (_room != default) return _room.Id;
                return -1;
            }
            set
            {
                if (Rooms != null)
                {
                    _room = Rooms
                        .Where(room => room.Id == value)
                        .FirstOrDefault();
                }
            }
        }
        public Room? SelectedRoom
        {
            get { return _room; }
            set { _room =  value; }
        }

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


        public virtual IEnumerable<Room>? Rooms { get; set; }


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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // departure date has to be after the arrival (or on the same day)
            if (ArrivalDate > DepartureDate)
            {
                yield return new ValidationResult(
                    "Prosimo, izberite smiselne datume - odhod naj bo za prihodom.",
                    new[] { nameof(ArrivalDate), nameof(DepartureDate) });
            }
        }
        #endregion

    }
}
