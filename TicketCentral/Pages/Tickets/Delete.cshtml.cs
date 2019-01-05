using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketCentral.Models;

namespace TicketCentral.Pages.Tickets
{
    public class DeleteModel : PageModel
    {
        private readonly TicketCentral.Models.TicketContext _context;

        public DeleteModel(TicketCentral.Models.TicketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket.AsNoTracking()
                .Include(t => t.Customer)
                .Include(t => t.VenueBooking).FirstOrDefaultAsync(m => m.TicketID == id);

            if (Ticket == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Ticket.AsNoTracking()
                .FirstOrDefaultAsync(t => t.TicketID == id);

            try
            {
                _context.Ticket.Remove(Ticket);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(".Delete", new { id, saveChangesError = true });
            }
        }
    }
}
