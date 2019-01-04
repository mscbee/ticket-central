using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketCentral.Models;

namespace TicketCentral.Pages.Venues
{
    public class CreateModel : PageModel
    {
        private readonly TicketCentral.Models.VenueContext _context;

        public CreateModel(TicketCentral.Models.VenueContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Venue Venue { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Venue.Add(Venue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}