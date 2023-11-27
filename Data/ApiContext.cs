using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBooking.Models;
using WebBooking.ViewModels;

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

        #region rooms
        private static string _roomNameForDropdown = "-- razpoložljive sobe --";

        public List<string?> RoomNames
        {
            get
            {
                return Rooms.Select(room => room.Name).ToList();
            }
        }

        public Room? GetRoomByName(string name)
        {
            return Rooms.FirstOrDefault(room => room.Name == name);
        }


        public List<Room> GetRoomsList()
        {
            List<Room> list = Rooms.Select(room => room).ToList();
            list.Insert(0, new Room() { Id = 0, Name = _roomNameForDropdown });

            return list;
        }
        #endregion
    }
}
