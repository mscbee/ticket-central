using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketCentral.Models
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name can not be longer than 50 characters.")]
        public string EventName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        public string OrganiserEmail { get; set; }
        public int VenueBookingID { get; set; }

        public VenueBooking VenueBooking { get; set; }
    }
}
