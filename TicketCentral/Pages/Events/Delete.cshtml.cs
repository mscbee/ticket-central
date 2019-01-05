using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketCentral.Models;

namespace TicketCentral.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly TicketCentral.Models.EventContext _context;

        public DeleteModel(TicketCentral.Models.EventContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.AsNoTracking()
                .FirstOrDefaultAsync(m => m.EventID == id);

            if (Event == null)
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

            Event = await _context.Event.AsNoTracking()
                .FirstOrDefaultAsync(e => e.EventID == id);

            try
            {
                _context.Event.Remove(Event);
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
