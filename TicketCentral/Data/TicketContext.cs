using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketCentral.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext (DbContextOptions<TicketContext> options)
            : base(options)
        {
        }

        public DbSet<TicketCentral.Models.Ticket> Ticket { get; set; }
    }
}
