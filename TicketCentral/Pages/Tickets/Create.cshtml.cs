using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketCentral.Models;

namespace TicketCentral.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly TicketCentral.Models.TicketContext _context;

        public CreateModel(TicketCentral.Models.TicketContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID");
        ViewData["VenueBookingID"] = new SelectList(_context.Set<VenueBooking>(), "VenueBookingID", "VenueBookingID");
            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ticket.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}