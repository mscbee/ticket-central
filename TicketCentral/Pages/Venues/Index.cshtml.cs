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
    public class IndexModel : PageModel
    {
        private readonly TicketCentral.Models.VenueContext _context;

        public IndexModel(TicketCentral.Models.VenueContext context)
        {
            _context = context;
        }

        public IList<Venue> Venue { get;set; }

        public async Task OnGetAsync()
        {
            Venue = await _context.Venue.ToListAsync();
        }
    }
}
