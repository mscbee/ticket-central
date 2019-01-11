using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace TicketCentral.Pages
{
    public class IndexModel : PageModel
    {

        private readonly TicketCentral.Models.BookingContext _context;

        public IndexModel(TicketCentral.Models.BookingContext context)
        {
            _context = context;
        }
        
        public void OnGet()
        {}

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
