using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebBooking.Models;

namespace WebBooking.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }
    }
}
