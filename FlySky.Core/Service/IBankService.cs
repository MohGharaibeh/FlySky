using FlySky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Service
{
    public interface IBankService
    {
        void CreateBank(Virtualbank bank);
        void UpdateBank(Virtualbank bank);
        void DeleteBank(int id);
        List<Virtualbank> GetAllBank();
        Virtualbank GetBankById(int id);
    }
}
