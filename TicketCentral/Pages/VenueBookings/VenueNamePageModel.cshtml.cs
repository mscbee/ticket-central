using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using TicketCentral.Models;

namespace TicketCentral.Pages.VenueBookings
{
    public class VenueNamePageModel: PageModel
    {
        public SelectList venueList { get; set; }
        public SelectList eventList { get; set; }
        public void PopulateVenueList(bool isVenue, BookingContext _context, object selection = null)
        {
            SelectListType(isVenue, _context, selection);
        }

        public void SelectListType(bool isVenue, BookingContext _context, object selection)
        {
            switch (isVenue) {
                case true:
                    var queryVenue = from v in _context.Venue orderby v.VenueName select v;
                    venueList = new SelectList(queryVenue.AsNoTracking(), "VenueID", "VenueName", selection);
                    break;
                case false:
                    var queryEvent = from e in _context.Event orderby e.EventName select e;
                    eventList = new SelectList(queryEvent.AsNoTracking(), "EventID", "EventName", selection);
                    break;
            }
        }
    }
}
