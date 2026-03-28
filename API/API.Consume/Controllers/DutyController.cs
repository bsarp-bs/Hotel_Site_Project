using API.BusinessLayer.Service;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutyController : ControllerBase
    {
        private readonly IDutyService _duty;

        public DutyController(IDutyService duty)
        {
            _duty = duty;
        }

        [HttpGet]
        public IActionResult DutyList()
        {
            var v = _duty.GetAllS();
            return Ok(v);
        }

        [HttpPost]
        public IActionResult AddDuty(Duty d) 
        {
            _duty.SInsert(d);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDuty(int id)
        {
            var v = _duty.Getbyid(id);
            _duty.SDelete(v);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDuty(Duty d) 
        {
            _duty.SUpdate(d);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetDuty(int id) 
        {
            var v = _duty.Getbyid(id);
            return Ok(v);
        }


    }
}
