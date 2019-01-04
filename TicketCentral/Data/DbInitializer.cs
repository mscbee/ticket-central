using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketCentral.Models;


namespace TicketCentral.Models
{
    public static class DbInitializer
    {
        public static void Initialize(BookingContext context)
        {
            if (context.VenueBooking.Any())
            {
                return;
            }

            var venues = new Venue[]
            {
                new Venue{VenueName="O2",VenueAddress="129 Somewhere Somewhere",VenuePostcode="SE15 2JP"},
                new Venue{VenueName="Wembley",VenueAddress="124 Somewhere Somewhere",VenuePostcode="HA3 6DE" },
                new Venue{VenueName="London Stadium",VenueAddress="126 Somewhere Somewhere",VenuePostcode="E15 7DJ"}
            };

            foreach (Venue v in venues)
            {
                context.Venue.Add(v);
            }
            context.SaveChanges();

            var events = new Event[]
            {
                new Event{EventName="Poppin' Molly",OrganiserEmail="joe@hotmail.com",VenueBookingID=1},
                new Event{EventName="S Club Party",OrganiserEmail="sclubmgmnt@hotmail.com",VenueBookingID=2},

            };

            foreach (Event e in events)
            {
                context.Event.Add(e);
            }
            context.SaveChanges();

            var venueBooking = new VenueBooking[]
            {
                new VenueBooking{EventID=1, VenueID=1, BookingManagerName="Luke", BookingManagerEmail="Luke@unknown.com", BookingDate="02082019"},
                new VenueBooking{EventID=2, VenueID=1, BookingManagerName="Charlene", BookingManagerEmail="Charlene@unknown.com", BookingDate="02082019"},
                new VenueBooking{EventID=1, VenueID=2, BookingManagerName="Luuuke", BookingManagerEmail="Lukeeee@unknown.com", BookingDate="02082019"},
                new VenueBooking{EventID=2, VenueID=2, BookingManagerName="Chaaaaarlene", BookingManagerEmail="Chaaaaarlene@unknown.com", BookingDate="02082019"},
            };
            foreach (VenueBooking vb in venueBooking)
            {
                context.VenueBooking.Add(vb);
            }
            context.SaveChanges();
        }
    }
}


