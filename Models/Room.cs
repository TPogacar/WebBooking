using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace WebBooking.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int PricePerNight { get; set; }

        public string? ShortDescription { get; set; }
        public string? Description { get; set; }

        public ICollection<Image>? AllImage { get; set; }
    }
}
