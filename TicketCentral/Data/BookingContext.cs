using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketCentral.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public DbSet<VenueBooking> VenueBooking { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        //Fluent API to allow configuration to be specified without modifying any entity classes 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VenueBooking>().ToTable("VenueBooking");
            modelBuilder.Entity<Venue>().ToTable("Venue");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
        }
    }
}
