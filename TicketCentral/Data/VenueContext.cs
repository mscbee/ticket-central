using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketCentral.Models
{
    public class VenueContext : DbContext
    {
        public VenueContext (DbContextOptions<VenueContext> options)
            : base(options)
        {
        }

        public DbSet<TicketCentral.Models.Venue> Venue { get; set; }
    }
}
