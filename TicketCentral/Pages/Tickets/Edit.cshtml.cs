using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketCentral.Models;

namespace TicketCentral.Pages.Tickets
{
    public class EditModel : PageModel
    {
        private readonly TicketCentral.Models.TicketContext _context;

        public EditModel(TicketCentral.Models.TicketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket
                .Include(t => t.Customer)
                .Include(t => t.VenueBooking).FirstOrDefaultAsync(m => m.TicketID == id);

            if (Ticket == null)
            {
                return NotFound();
            }
           ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID");
           ViewData["VenueBookingID"] = new SelectList(_context.Set<VenueBooking>(), "VenueBookingID", "VenueBookingID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket.TicketID))
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

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.TicketID == id);
        }
    }
}
