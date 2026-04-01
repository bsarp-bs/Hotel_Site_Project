using JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult CrtVisitor() 
        {
            return Ok(new CreateTokenModel().CrtTokenVisitor());
        }

        [HttpGet("[action]")]
        public IActionResult CrtAdmin()
        {
            return Ok(new CreateTokenModel().CrtTokenAdmin());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public IActionResult IndexTest()
        {
            return Ok("Hoşgeldiniz");
        }

        [Authorize(Roles = "Visitor")]
        [HttpGet("[action]")]
        public IActionResult IndexTest2()
        {
            return Ok("Hoşgeldiniz");
        }
    }
}
