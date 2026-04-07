using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WEB_UI.Controllers
{
    [AllowAnonymous]
    public class UserListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> UserListIndex()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7227/api/UserList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AppUser>>(jsonData);
                return View(values ?? new List<AppUser>());
            }

            return View(new List<AppUser>());
        }
    }
}
