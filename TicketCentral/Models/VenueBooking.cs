using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketCentral.Models
{
    public class VenueBooking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VenueBookingID { get; set; }
        [Display(Name = "Choose a Event")]
        public int EventID { get; set; }
        [Display(Name = "Choose a Venue")]
        public int VenueID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string BookingManagerName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        public string BookingManagerEmail { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookingDate { get; set; }

        public Event Event { get; set; }
        public Venue Venue { get; set; }

    }
}
