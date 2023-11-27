using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBooking.Controllers;
using WebBooking.Models;

namespace WebBooking.ViewModels
{
    public class RoomViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Ime sobe")]
        public string? Name { get; set; }

        [Required]
        [DisplayName("Cena na nočitev")]
        public int PricePerNight { get; set; }

        [DisplayName("Kratek opis")]
        public string? ShortDescription { get; set; }

        [DisplayName("Dolgi opis")]
        public string? Description { get; set; }

        [DisplayName("Slika sobe")]
        public ICollection<int>? ImageId { get; set; }


        public Reservation Reservation { get; set; }
    }
}
