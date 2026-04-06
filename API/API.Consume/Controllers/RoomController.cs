using API.BusinessLayer.Service;
using API.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _room;
        private readonly IValidator<Room> _roomValidator;

        public RoomController(IRoomService room, IValidator<Room> roomValidator)
        {
            _room = room;
            _roomValidator = roomValidator;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var value = _room.GetAllS();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            var validationResult = _roomValidator.Validate(room);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            _room.SInsert(room);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var value = _room.Getbyid(id);
            _room.SDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditRoom(Room room)
        {
            var validationResult = _roomValidator.Validate(room);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            _room.SUpdate(room);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var value = _room.Getbyid(id);
            return Ok(value);
        }
    }
}
