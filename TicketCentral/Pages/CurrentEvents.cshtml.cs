using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketCentral.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace TicketCentral.Pages
{
    public class CurrentEventsModel : PageModel
    {
        private readonly TicketCentral.Models.BookingContext _context;

        public CurrentEventsModel(TicketCentral.Models.BookingContext context)
        {
            _context = context;
        }

        public IList<VenueBooking> VenueBooking { get; set; }

        public async Task OnGetAsync()
        {
            VenueBooking = await _context.VenueBooking
                .Include(v => v.Venue).ToListAsync();
        }

        [HttpPost]
        public ActionResult BookTicket(int id, int cId)
        {
            var Ticket = new TicketCentral.Models.Ticket { VenueBookingID = id, CustomerID = cId };

            try
            {
                _context.Ticket.Add(Ticket);
                _context.SaveChanges();
            }
            catch (DBConcurrencyException)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

