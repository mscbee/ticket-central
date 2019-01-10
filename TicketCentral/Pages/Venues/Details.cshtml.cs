using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketCentral.Models;

namespace TicketCentral.Pages.Venues
{
    public class DetailsModel : PageModel
    {
        private readonly TicketCentral.Models.BookingContext _context;

        public DetailsModel(TicketCentral.Models.BookingContext context)
        {
            _context = context;
        }

        public Venue Venue { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venue = await _context.Venue.FirstOrDefaultAsync(m => m.VenueID == id);

            if (Venue == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
