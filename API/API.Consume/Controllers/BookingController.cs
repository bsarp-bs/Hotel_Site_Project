using API.BusinessLayer.Service;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var value = _bookingService.GetAllS();
            return Ok(value);

        }

        [HttpGet("{id}")]
        public IActionResult BookingById(int id)
        {
            var value = _bookingService.Getbyid(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking b)
        { 
            _bookingService.SInsert(b);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditBooking(Booking b)
        {
            _bookingService.SUpdate(b);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.Getbyid(id);
            _bookingService.SDelete(value);
            return Ok();
        }

    }
}
