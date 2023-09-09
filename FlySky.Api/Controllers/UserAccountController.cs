using FlySky.Core.Data;
using FlySky.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        [HttpGet]
        public List<Useracount> AllUsers()
        {
            return _userAccountService.AllUsers();
        }
        [HttpPost]
        public bool CreateUser(Useracount useracount)
        {
            return _userAccountService.CreateUser(useracount);
        }
        [HttpPut]
        public bool UpdateUser(Useracount useracount)
        {
            return _userAccountService.UpdateUser(useracount);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteUser(int id)
        {
            return _userAccountService.DeleteUser(id);
        }
        [Route("get/{id}")]
        [HttpGet]
        public Useracount UserById(int id)
        {
            return _userAccountService.UserById(id);
        }
    }
}
