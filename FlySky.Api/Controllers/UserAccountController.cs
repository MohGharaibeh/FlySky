using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*using Newtonsoft.Json;
using Newtonsoft.Json.Linq;*/
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        public bool CreateUser([FromBody] Useracount useracount)
        {
            return _userAccountService.CreateUser(useracount);
        }
        [Route("uploadImage")]
        [HttpPost]
        public Useracount UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\DELL\\source\\repos\\FlySkyFE\\src\\assets\\ApiImage", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Useracount user = new Useracount();
            user.Image = fileName;
            return user;
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
        [HttpPost]
        [Route("ByDate")]
        public List<Flight> SearchByDate([FromBody] Flight flight)
        {
            return _userAccountService.SearchByDate(flight);
        }
        [HttpPost]
        [Route("ByCountry")]
        public List<Flight> SearchByCountry([FromBody] Flight flight)
        {
            return _userAccountService.SearchByCountry(flight);
        }

        [Route("getres/{id}")]
        [HttpGet]
        public List<ReservedFlightByUser> ReservedUser(int id)
        {
            return _userAccountService.ReservedUser(id);
        }

        [Route("track/{id}")]
        [HttpGet]
        public List<TrackingMap> TrackInMap(int id)
        {
            return _userAccountService.TrackInMap(id);
        }

        [Route("chickUser/{email}")]
        [HttpGet]
        public Useracount ChickUser(string email)
        {
            return _userAccountService.ChickUser(email);
        }
       /* [HttpPost]
        [Route("chat")]
        public async Task<IActionResult> chatAsync([FromBody] ChatRequest requests)
        {
            if (requests != null && !string.IsNullOrWhiteSpace(requests.Question))
            {
                var client = new HttpClient();

                var requestBody = new { question = requests.Question };
                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:4000/chatbot");
                request.Content = content;

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var responseObject = JsonConvert.DeserializeObject<JObject>(jsonResponse);

                string answer = responseObject["response_text"]?.ToString();

                return Ok(new { answer });
            }

            return BadRequest(new { answer = "Please provide a valid question." });
        }*/
    }
}
