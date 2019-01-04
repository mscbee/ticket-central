using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketCentral.Models
{
    public class Venue
    {
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public string VenuePostcode { get; set; }
        public string BookingDate { get; set; }
        public int IsAvailable { get; set; }
    }
}
