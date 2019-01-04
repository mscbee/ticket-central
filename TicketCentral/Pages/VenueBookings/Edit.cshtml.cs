using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketCentral.Models;

namespace TicketCentral.Pages.VenueBookings
{
    public class EditModel : PageModel
    {
        private readonly TicketCentral.Models.BookingContext _context;

        public EditModel(TicketCentral.Models.BookingContext context)
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
           ViewData["VenueID"] = new SelectList(_context.Venue, "VenueID", "VenueID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VenueBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueBookingExists(VenueBooking.VenueBookingID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VenueBookingExists(int id)
        {
            return _context.VenueBooking.Any(e => e.VenueBookingID == id);
        }
    }
}
