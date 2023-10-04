using FlySky.Core.Data;
using FlySky.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService bankService;
        public BankController(IBankService bankService)
        {
            this.bankService = bankService;
        }
        [HttpPost]
        public void CreateBank(Virtualbank bank)
        {
            bankService.CreateBank(bank);
        }
        [HttpPut]
        public void UpdateBank(Virtualbank bank)
        {
            bankService.UpdateBank(bank);
        }
        [HttpDelete]
        public void DeleteBank(int id)
        {
            bankService.DeleteBank(id);
        }
        [HttpGet]
        public List<Virtualbank> GetAllBank()
        {
            return bankService.GetAllBank();
        }
        [HttpGet]
        [Route("GetByID/{id}")]
        public Virtualbank GetBankById(int id)
        {
            return bankService.GetBankById(id);
        }

        [HttpPost]
        [Route("checkBank")]
        public Virtualbank CheckBank([FromBody]Virtualbank bank)
        {
            return bankService.CheckBank(bank);
        }

        [HttpPost]
        [Route("checkBalance")]
        public Virtualbank CheckBalance([FromBody]Virtualbank bank)
        {
            return bankService.CheckBalance(bank);
        }
    }
}
