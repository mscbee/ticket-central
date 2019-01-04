using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketCentral.Models
{
    public class Tickets
    {
        public int TicketID { get; set; }
        public int VenueBookingID { get; set; }
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
        public VenueBooking VenueBooking { get; set; }
    }
}
