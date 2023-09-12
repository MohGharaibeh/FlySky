using FlySky.Core.Data;
using FlySky.Core.Service;
using FlySky.Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }
        [HttpPost]
        public void CreateContact([FromBody] Contact contact)
        {
           
            contactService.CreateContact(contact);
        }
        [Route("uploadImage")]
        [HttpPost]
        public Useracount UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Useracount user = new Useracount();
            user.Image = fileName;
            return user;
        }
        [HttpPut]
        public void UpdateContact(Contact contact)
        {
            contactService.UpdateContact(contact);
        }
        [HttpDelete]
        public void DeleteContact(int id)
        {
            contactService.DeleteContact(id);
        }
        [HttpGet]
        public List<Contact> GetAllContact()
        {
            return contactService.GetAllContact();
        }
        [HttpGet]
        [Route("GetByID/{id}")]
        public Contact GetContactById(int id)
        {
            return contactService.GetContactById(id);
        }
    }
}
