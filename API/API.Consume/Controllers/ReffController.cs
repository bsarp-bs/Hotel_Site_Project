using API.BusinessLayer.Service;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReffController : ControllerBase
    {
        private readonly IReffService _reff;

        public ReffController(IReffService reff)
        {
            _reff = reff;
        }

        [HttpGet]
        public IActionResult ReffList()
        {
            var v = _reff.GetAllS();
            return Ok(v);
        }

        [HttpPost]
        public IActionResult AddReff(Reff d)
        {
            _reff.SInsert(d);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReff(int id)
        {
            var v = _reff.Getbyid(id);
            _reff.SDelete(v);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateReff(Reff d)
        {
            _reff.SUpdate(d);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetReff(int id)
        {
            var v = _reff.Getbyid(id);
            return Ok(v);
        }
    }
}
