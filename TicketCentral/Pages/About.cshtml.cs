using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TicketCentral.Pages
{
    public class AboutModel : PageModel
    {
        public string msgWelcome { get; set; }
        public string msgWhoAreWe { get; set; }

        public void OnGet()
        {
            msgWelcome = "Welcome to Ticket Central, our objective is to connect both events and enthusiasts together.";
            msgWhoAreWe = "Ticket Central is a leading self-service online marketing and ticketing company, dedicated to the independent venue, organiser and enthusiast." +
                " Our proprietary system allows venues and event promoters of any size to ticket and market a full range of events on our web platform. Ticket Central helps fans buy tickets online and " +
                "for over 2 months we stayed true to our commitment for the added value of TicketCentral.com, " +
                "integration and distribution, soon to be one of the world's largest e-commerce and ticketing sites online, Ticket Central makes it easy for fans to find tickets. Ticket Central currently " +
                "serves a variety of venues, events, and promoters across London, soon... the rest of the United Kingdom.";
        }
    }
}
