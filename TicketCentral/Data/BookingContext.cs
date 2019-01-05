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

        public DbSet<VenueBooking> VenueBooking { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Event> Event { get; set; }
    }
}
