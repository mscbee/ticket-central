using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace TicketCentral.Models
{
    public class VenueBooking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VenueBookingID {get; set;}
        public int EventID { get; set; }
        public int VenueID { get; set; }
        public string BookingManagerName { get; set; }
        public string BookingManagerEmail { get; set; }
        public string BookingDate { get; set; }

        public Event Event { get; set; }
        public Venue Venue { get; set; }

    }
}
