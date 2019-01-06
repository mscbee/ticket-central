using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketCentral.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketCentral.Pages.VenueBookings
{
    public class CreateModel : VenueNamePageModel
    {
        
        private readonly TicketCentral.Models.BookingContext _context;

        public CreateModel(TicketCentral.Models.BookingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            bool isVenue = true;
            bool isEvent = false; //this fullfils switch case false condition.
            PopulateVenueList(isVenue, _context);
            PopulateVenueList(isEvent, _context);
            return Page();
        }

        [BindProperty]
        public VenueBooking VenueBooking { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VenueBooking.Add(VenueBooking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}