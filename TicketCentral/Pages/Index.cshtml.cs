using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TicketCentral.Pages
{
    public class IndexModel : PageModel
    {

        private readonly TicketCentral.Models.BookingContext _context;

        public IndexModel(TicketCentral.Models.BookingContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            
        }
    }
}
