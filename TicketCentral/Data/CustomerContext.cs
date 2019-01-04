using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketCentral.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext (DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<TicketCentral.Models.Customer> Customer { get; set; }
    }
}
