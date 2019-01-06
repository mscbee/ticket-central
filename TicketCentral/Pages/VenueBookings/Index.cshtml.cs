using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketCentral.Models;

namespace TicketCentral.Pages.VenueBookings
{
    public class IndexModel : PageModel
    {
        private readonly TicketCentral.Models.BookingContext _context;

        public IndexModel(TicketCentral.Models.BookingContext context)
        {
            _context = context;
        }

        public string sortByName { get; set; }
        public string sortByDate { get; set; }
        public string sortByVenue { get; set; }
        public string sortByEvent { get; set; }

        public string currentFilter { get; set; }
        public string currentSort { get; set; }


        public IList<VenueBooking> VenueBooking { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            /*
            sortByDate = sortOrder == "Date" ? "date_desc" : "Date";
            sortByVenue = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            sortByEvent = String.IsNullOrEmpty(sortOrder) ? "event_desc" : "";

            IQueryable<VenueBooking> venueBookingIQ = from s in _context.VenueBooking
                                            select s;

            switch (sortOrder)
            {
                case "name_desc":
                    venueBookingIQ = venueBookingIQ.OrderByDescending(s => s.Venue.VenueName);
                    break;
                case "Date":
                    venueBookingIQ = venueBookingIQ.OrderBy(s => s.BookingDate);
                    break;
                case "date_desc":
                    venueBookingIQ = venueBookingIQ.OrderByDescending(s => s.BookingDate);
                    break;
                case "event_desc":
                    venueBookingIQ = venueBookingIQ.OrderByDescending(s => s.Event.EventName);
                    break;
                
            }
            */

            VenueBooking = await _context.VenueBooking
                .Include(v => v.Venue).ToListAsync();
        }
    }
}
