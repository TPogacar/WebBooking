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
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly ArrivalDate { get; set; }

        [Required]
        public DateOnly DepartureDate { get; set; }

        [Required]
        [BindProperty]
        public Room? SelectedRoom { get; set; }

        [Required]
        public string? NameAndSurname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Footnote { get; set; }


        public virtual IEnumerable<Room>? Rooms { get; set; }
    }
}
