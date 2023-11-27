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
            ViewBag.lstRooms = _context.GetRoomsList();

            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArrivalDate,DepartureDate,SelectedRoom,NameAndSurname,EmailAddress,PhoneNumber,Footnote")] Reservation reservation)
        {
            // validation based on EF (validation of the email included)
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();

                // additional validation
                // arrival date has to be in the present or the future

                // departure date has to be after the arrival


                // user has to recieve thank-you email

                // the hotel gets the email with user's informations and the total cost of his stay

                return RedirectToAction(nameof(Index));
            }

            //ViewBag.listOfRooms = GetRoomsList();
            return View(reservation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
