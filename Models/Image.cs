using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBooking.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public byte[]? Content { get; set; }


        //public virtual Room Room { get; set; }
    }
}
