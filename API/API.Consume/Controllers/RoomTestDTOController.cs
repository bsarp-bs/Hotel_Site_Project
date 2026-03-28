using API.BusinessLayer.Service;
using API.DtoLayer;
using API.EntityLayer.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTestDTOController : ControllerBase
    {
        private readonly IRoomService _room;
        private readonly IMapper _mapper;

        // user can test DTO Layer process with this controller on swagger. Not for the ui layer, use for on swagger.

        public RoomTestDTOController(IRoomService room, IMapper mapper)
        {
            _room = room;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var value = _room.GetAllS();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddRoom(RoomDTO r)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var value = _mapper.Map<Room>(r);
            _room.SInsert(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditRoom(RoomDTO r)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var value = _mapper.Map<Room>(r);
            _room.SUpdate(value);
            return Ok("Başarıyla Güncellendi");
        }
    }
}

