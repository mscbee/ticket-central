using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketCentral.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string OrganiserEmail { get; set; }
        public int VenueBookingID { get; set; }

    }
}
