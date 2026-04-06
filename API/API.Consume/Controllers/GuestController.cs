using API.BusinessLayer.Service;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guest;

        public GuestController(IGuestService guest)
        {
            _guest = guest;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var value = _guest.GetAllS();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            _guest.SInsert(guest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var value = _guest.Getbyid(id);
            _guest.SDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGuest(Guest guest)
        {
            _guest.SUpdate(guest);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var value = _guest.Getbyid(id);
            return Ok(value);
        }
    }
}
