using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketCentral.Models
{
    public class CardPayment
    {
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public string CardOwner { get; set; }
        public int CardNumber { get; set; }
        public int SecurityNumber { get; set; }

        public Customer Customer { get; set; }
    }
}
