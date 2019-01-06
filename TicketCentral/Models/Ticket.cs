using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketCentral.Models
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketID { get; set; }
        public int VenueBookingID { get; set; }
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
        public VenueBooking VenueBooking { get; set; }
    }
}
