using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketCentral.Models;

namespace TicketCentral.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly TicketCentral.Models.CustomerContext _context;

        public DeleteModel(TicketCentral.Models.CustomerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.AsNoTracking()
                .FirstOrDefaultAsync(m => m.CustomerID == id);

            if (Customer == null)
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

            Customer = await _context.Customer.AsNoTracking()
                .FirstOrDefaultAsync(c => c.CustomerID == id);

            try
            {
                _context.Customer.Remove(Customer);
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
