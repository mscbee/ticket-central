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

        public IList<VenueBooking> VenueBooking { get;set; }

        public async Task OnGetAsync()
        {
            VenueBooking = await _context.VenueBooking
                .Include(v => v.Venue).ToListAsync();
        }
    }
}
