using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketCentral.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext (DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public DbSet<TicketCentral.Models.VenueBooking> VenueBooking { get; set; }
        public DbSet<TicketCentral.Models.Venue> Venue { get; set; }
        public DbSet<TicketCentral.Models.Event> Event { get; set; }
    }
}
