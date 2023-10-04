using FlySky.Core.Data;
using FlySky.Core.Repository;
using FlySky.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Service
{
    public class BankService: IBankService
    {
        private readonly IBankRepository _bankRepository;
        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }
        public void CreateBank(Virtualbank bank)
        {
            _bankRepository.CreateBank(bank);
        }
        public void UpdateBank(Virtualbank bank)
        {
            _bankRepository.UpdateBank(bank);
        }
        public void DeleteBank(int id)
        {
            _bankRepository.DeleteBank(id);
        }
        public List<Virtualbank> GetAllBank()
        {
            return _bankRepository.GetAllBank();
        }
        public Virtualbank GetBankById(int id)
        {
           return _bankRepository.GetBankById(id);
        }

        public Virtualbank CheckBank(Virtualbank bank)
        {
            return _bankRepository.CheckBank(bank);
        }
        public Virtualbank CheckBalance(Virtualbank bank)
        {
            return _bankRepository.CheckBalance(bank);
        }

    }
}
