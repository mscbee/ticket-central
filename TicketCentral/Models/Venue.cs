using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketCentral.Models
{
    public class Venue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VenueID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string VenueName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Address can not be longer than 50 characters.")]
        public string VenueAddress { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Post code can not be longer than 10 characters.")]
        public string VenuePostcode { get; set; }

    }
}
