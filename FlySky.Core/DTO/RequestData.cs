using FlySky.Core.Data;
using FlySky.Infra.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.DTO
{
    public class RequestData
    {
        public virtual Reservedflight Reservedflight { get; set; } 
        public virtual BankData Data { get; set; }
    }
}
