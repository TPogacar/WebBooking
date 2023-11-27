using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBooking.Models;

namespace WebBooking.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Image> Images { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }


        #region methods
        public Room? GetRoomById(int id)
        {
            if (!Rooms.Any())
            {
                return default;
            }
            return Rooms
                .Where(room => room.Id == id)?
                .FirstOrDefault();
        }
        #endregion
    }
}
