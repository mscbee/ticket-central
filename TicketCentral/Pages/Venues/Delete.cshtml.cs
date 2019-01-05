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
    public class DeleteModel : PageModel
    {
        private readonly TicketCentral.Models.VenueContext _context;

        public DeleteModel(TicketCentral.Models.VenueContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Venue Venue { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venue = await _context.Venue.AsNoTracking()
                .FirstOrDefaultAsync(m => m.VenueID == id);

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

            Venue = await _context.Venue.AsNoTracking()
                .FirstOrDefaultAsync(v => v.VenueID == id);

            try
            {
                _context.Venue.Remove(Venue);
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
