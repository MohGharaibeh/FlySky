using FlySky.Core.Data;
using FlySky.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public bool CreateUser([FromForm] Useracount useracount, [FromForm] IFormFile image)
        {
            if (image != null)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine("Images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                useracount.Image = fileName;
            }
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
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Useracount useracount)
        {
            if (!ModelState.IsValid)
            {
                // Handle validation errors
                return BadRequest(ModelState);
            }
            var tok = _userAccountService.Login(useracount);
            if (tok == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(tok);
            }
        }
    }
}
