using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketCentral.Models
{
    public class Customer
    {
        // Using identity, email is username.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; } 

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact number needs to be 11 characters.")]
        public int ContactNumber { get; set; }
        public int HasSubscription { get; set; }

        public CustomerStatus Status { get; set; }
    }

    public enum CustomerStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
