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
    public class IndexModel : PageModel
    {
        private readonly TicketCentral.Models.TicketContext _context;

        public IndexModel(TicketCentral.Models.TicketContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; }

        public async Task OnGetAsync()
        {
            Ticket = await _context.Ticket
                .Include(t => t.Customer)
                .Include(t => t.VenueBooking).ToListAsync();
        }
    }
}
