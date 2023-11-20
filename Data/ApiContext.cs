using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebBooking.Models;

namespace WebBooking.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<WebBooking.Models.Room> Rooms { get; set; }
        public DbSet<WebBooking.Models.Reservation> Reservation { get; set; } = default!;

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }
    }
}
