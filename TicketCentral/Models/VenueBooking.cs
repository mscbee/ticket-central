using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketCentral.Models
{
    public class VenueBooking
    {
        public int VenueBookingID {get; set;}
        public int EventID { get; set; }
        public int PaymentID { get; set; }
        public int EventManagerID { get; set; }
        public int VenueID { get; set; }

        public Event Event { get; set; }
        public CardPayment CardPayment { get; set; }
        public EventManager EventManager { get; set; }
        public Venue Venue { get; set; }
    }
}
