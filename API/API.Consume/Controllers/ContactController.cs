using API.BusinessLayer.Service;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _contactService.GetAllS();
            return Ok(value);

        }

        [HttpGet("{id}")]
        public IActionResult ContactById(int id)
        {
            var value = _contactService.Getbyid(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddContact(Contact b)
        {
            _contactService.SInsert(b);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditContact(Contact b)
        {
            _contactService.SUpdate(b);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.Getbyid(id);
            _contactService.SDelete(value);
            return Ok();
        }
    }
}
