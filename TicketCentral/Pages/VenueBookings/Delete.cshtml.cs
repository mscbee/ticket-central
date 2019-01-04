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
    public class DeleteModel : PageModel
    {
        private readonly TicketCentral.Models.BookingContext _context;

        public DeleteModel(TicketCentral.Models.BookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VenueBooking VenueBooking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VenueBooking = await _context.VenueBooking
                .Include(v => v.Venue).FirstOrDefaultAsync(m => m.VenueBookingID == id);

            if (VenueBooking == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VenueBooking = await _context.VenueBooking.FindAsync(id);

            if (VenueBooking != null)
            {
                _context.VenueBooking.Remove(VenueBooking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
