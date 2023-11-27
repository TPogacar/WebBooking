using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using WebBooking.Data;
using WebBooking.Models;

namespace WebBooking.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApiContext _context;

        public ReservationsController(ApiContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservation.ToListAsync());
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            // all rooms have to be offered in dropdown 
            PopulateRoomDropdown();
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArrivalDate,DepartureDate,RoomId,NameAndSurname,EmailAddress,PhoneNumber,Footnote")] Reservation reservation)
        {
            // validation based on EF (validation of the email included)
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();

                // additional validation
                // arrival date has to be in the present or the future

                


                // user has to recieve thank-you email

                // the hotel gets the email with user's informations and the total cost of his stay

                return RedirectToAction(nameof(Index));
            }

            PopulateRoomDropdown();
            return View(reservation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private List<Room> GetRoomList()
        {
            List<Room> roomList = new List<Room>();
            var list = _context.Rooms.Select(room => room);
            if (list != null &&
                list.FirstOrDefault() != default)
            {
                roomList = list.ToList<Room>();
            }

            roomList.Insert(0, new Room() { Id = 0, Name = "-- razpoložljive sobe --" });
            return roomList;
        }

        private void PopulateRoomDropdown(object selectedRoom=null)
        {
            ViewBag.lstRooms = new SelectList(GetRoomList(), "Id", "Name", 0);
        }
    }
}
