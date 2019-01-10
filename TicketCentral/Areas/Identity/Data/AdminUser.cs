using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TicketCentral.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AdminUser class
    public class AdminUser : IdentityUser
    {
        [PersonalData]
        public String Name { get; set; }
    }
}
