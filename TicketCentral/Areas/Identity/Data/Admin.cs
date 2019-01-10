using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TicketCentral.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Admin class
    public class Admin : IdentityUser
    {
        [PersonalData]
        public string Username { get; set; }
        [PersonalData]
        public string Password { get; set; }
    }
}
