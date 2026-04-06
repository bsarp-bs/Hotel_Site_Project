using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using WEB_UI.UI_DTO.RegisterDTOs;

namespace WEB_UI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult RegisterIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterIndex(InsertRegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7227/api/Register", registerDto);

            if (response.IsSuccessStatusCode)
            {
                TempData["RegisterSuccess"] = "Kayit basarili. Giris sayfasi hazir olana kadar bu ekranda kalabilirsin.";
                return RedirectToAction("RegisterIndex");
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
                ModelState.AddModelError(string.Empty, "Kayit sirasinda bir hata olustu.");
            }

            return View(registerDto);
        }
    }
}
