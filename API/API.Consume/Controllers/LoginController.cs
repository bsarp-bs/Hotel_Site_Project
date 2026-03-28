using API.DtoLayer;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                return BadRequest(validationErrors);
            }

            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user is null)
            {
                return BadRequest(new List<string> { "Kullanici adi veya sifre hatali." });
            }

            var passwordResult = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!passwordResult)
            {
                return BadRequest(new List<string> { "Kullanici adi veya sifre hatali." });
            }

            return Ok();
        }
    }
}
