using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Invoice
{
    public class BankData
    {
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal NumOfTicket { get; set; }
        public string UserEmail { get; set; }
        public DateTime ReservedDate { get; set; }

    }


}
