using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
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

        // GET: Reservations/Create
        public IActionResult Create()
        {
            // set default values for dates
            Reservation reservation = new Reservation()
            {
                ArrivalDate = DateOnly.FromDateTime(DateTime.Today),
                DepartureDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1))
            };

            // all rooms have to be offered in dropdown
            PopulateRoomDropdown();

            return View(reservation);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArrivalDate,DepartureDate,RoomId,NameAndSurname,EmailAddress,PhoneNumber,Footnote,Rooms")] Reservation reservation)
        {
            // set selected room
            reservation.SelectedRoom = _context.GetRoomById(reservation.RoomId);

            // validation based on EF (validation of the email included)
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();

                // user has to recieve thank-you email
                SendEmailConfirmation(
                    reservation.EmailAddress,
                    "Potrditev rezervacije sobe",
                    GetEmailBodyForCostumer(reservation));

                // the hotel gets the email with user's informations and the total cost of his stay
                SendEmailConfirmation(
                    "pogacar.tami@gmail.com",  // hotel's email
                    "Potrditev rezervacije sobe",
                    GetEmailBodyForHotel(reservation));

                return RedirectToAction("Index", "HomeController");
            }

            PopulateRoomDropdown();
            return View(reservation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        #region RoomMethods
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

        private void PopulateRoomDropdown()
        {            
            ViewBag.lstRooms = new SelectList(_context.Rooms.Select(room => room).ToList(), "Id", "Name", 0);
        }
        #endregion


        #region Email
        /// <summary>
        /// user recieves thank-you email
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        private string GetEmailBodyForCostumer(Reservation reservation)
        {
            int durationOfReservation = Math.Max(1, reservation.DepartureDate.DayNumber - reservation.ArrivalDate.DayNumber);

            return "Hvala za oddano povpraševanje!\n\n" +
                "Datum registracije: " + reservation.ArrivalDate.ToString() + "\n" +
                "Datum odjave: " + reservation.DepartureDate.ToString() + "\n" +
                "Izbrana soba: " + reservation.SelectedRoom.Name + "\n" +
                "Skupaj za plačilo: " + durationOfReservation * reservation.SelectedRoom.PricePerNight + "\n\n" +
                "Želimo Vam lep preostanek dneva in se že veselimo Vašega prihoda.";
        }

        /// <summary>
        /// the hotel gets the email with user's informations and the total cost of his stay
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        private string GetEmailBodyForHotel(Reservation reservation)
        {
            return "Čestitamo! Prejeli ste novo rezervacijo.\n\n" +
                "Ime in priimek: " + reservation.NameAndSurname + "\n" +
                "Tel. št.: " + reservation.PhoneNumber + "\n" +
                "Email: " + reservation.EmailAddress + "\n" +
                "Datum registracije: " + reservation.ArrivalDate.ToString() + "\n" +
                "Datum odjave: " + reservation.DepartureDate.ToString() + "\n" +
                "Sporočilo: " + reservation.Footnote + "\n\n";
        }

        private void SendEmailConfirmation(string email, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage("veliki.posiljalec.mailov@gmail.com", email, subject, body);
                NetworkCredential netCred = new NetworkCredential("veliki.posiljalec.mailov@gmail.com", "Geslo!12");
                SmtpClient smtpobj = new SmtpClient("smtp.live.com", 587);
                smtpobj.EnableSsl = true;
                smtpobj.Credentials = netCred;
                smtpobj.Send(message);
            }
            catch(Exception ex)
            {
                throw (new Exception("An Exception accured while sending Email. Email was not send.\n" + ex));
            }
        }
        #endregion
    }
}
