using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBooking.Models
{
    public class Room
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        
        [Column(Order = 1)]
        [Required]
        public string? Name { get; set; }

        [Required]
        [Column(Order = 2)]
        public int PricePerNight { get; set; }

        public string? ShortDescription { get; set; }

        public string? Description { get; set; }

        [ForeignKey("Image")]
        [Column(Order = 10)]
        public virtual ICollection<Image>? Images { get; set; }
    }
}
