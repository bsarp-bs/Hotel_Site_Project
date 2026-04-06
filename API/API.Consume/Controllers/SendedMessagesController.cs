using API.BusinessLayer.Service;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendedMessagesController : ControllerBase
    {
        private readonly ISendedMessagesService _sendedMessagesService;

        public SendedMessagesController(ISendedMessagesService sendedMessagesService)
        {
            _sendedMessagesService = sendedMessagesService;
        }

        [HttpGet]
        public ActionResult SendedMessagesList()
        {
            var value = _sendedMessagesService.GetAllS();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public ActionResult GetByIDMessages(int id)
        {
            var value = _sendedMessagesService.Getbyid(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult SendedMessagesPost(SendedMessages sm)
        {
            _sendedMessagesService.SInsert(sm);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _sendedMessagesService.Getbyid(id);
            _sendedMessagesService.SDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult PutSendedMessages(SendedMessages sm)
        {
            _sendedMessagesService.SUpdate(sm);
            return Ok();
        }

    }
}
