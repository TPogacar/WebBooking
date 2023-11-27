using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBooking.Data;
using WebBooking.Models;

namespace WebBooking.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApiContext _context;

        public RoomsController(ApiContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rooms.ToListAsync());
        }


        private bool RoomExists(string name)
        {
            return _context.Rooms.Any(e => e.Name == name);
        }
    }
}
