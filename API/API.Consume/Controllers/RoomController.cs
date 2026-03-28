using API.BusinessLayer.Service;
using API.DtoLayer;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _room;

        public RoomController(IRoomService room)
        {
            _room = room;
        }

        [HttpGet]
        public IActionResult RoomList() 
        {
            var value = _room.GetAllS();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddRoom(Room r) 
        {
            _room.SInsert(r);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var v = _room.Getbyid(id);
            _room.SDelete(v);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditRoom(Room r)
        {
            _room.SUpdate(r);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var v = _room.Getbyid(id);
            return Ok(v);
        }
    }
}
