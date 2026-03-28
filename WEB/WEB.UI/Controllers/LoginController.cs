using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using WEB_UI.UI_DTO.LoginDTOs;

namespace WEB_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginIndex(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7227/api/Login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamIndex", "Team");
            }

            var errors = await response.Content.ReadFromJsonAsync<List<string>>();

            if (errors is not null)
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Giris sirasinda bir hata olustu.");
            }

            return View(loginDto);
        }
    }
}
