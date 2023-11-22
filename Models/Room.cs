using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WebBooking.Models
{
    public class Room
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        
        [Column(Order = 1)]
        [Required]
        [DisplayName("Ime sobe")]
        public string? Name { get; set; }

        [Required]
        [Column(Order = 2)]
        [DisplayName("Cena na nočitev")]
        public int PricePerNight { get; set; }

        [DisplayName("Kratek opis")]
        public string? ShortDescription { get; set; }

        [DisplayName("Dolgi opis")]
        public string? Description { get; set; }

        [ForeignKey("Image")]
        [Column(Order = 10)]
        [DisplayName("Slika sobe")]
        public virtual ICollection<Image>? Images { get; set; }
    }
}
