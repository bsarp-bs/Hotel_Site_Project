using API.BusinessLayer.Service;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
       private readonly ISubscribeService _subs;

        public SubscribeController(ISubscribeService subs)
        {
            _subs = subs;
        }

        [HttpGet]
        public IActionResult SubsList()
        {
            var v = _subs.GetAllS();
            return Ok(v);
        }

        [HttpPost]
        public IActionResult AddSubs(Subscribe d)
        {
            _subs.SInsert(d);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteSubs(int id)
        {
            var v = _subs.Getbyid(id);
            _subs.SDelete(v);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSubs(Subscribe d)
        {
            _subs.SUpdate(d);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSubs(int id)
        {
            var v = _subs.Getbyid(id);
            return Ok(v);
        }
    }
}
