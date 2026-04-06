using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WEB_UI.UI_DTO.GuestDTOs;

namespace WEB_UI.Controllers
{
    public class GuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GuestIndex()
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync("https://localhost:7227/api/Guest");

            if (responseM.IsSuccessStatusCode)
            {
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ViewGuestDto>>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuest(InsertGuestDto guestDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(guestDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseM = await client.PostAsync("https://localhost:7227/api/Guest", stringContent);

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("GuestIndex");
            }

            return View();
        }

        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.DeleteAsync($"https://localhost:7227/api/Guest/{id}");

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("GuestIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync($"https://localhost:7227/api/Guest/{id}");

            if (responseM.IsSuccessStatusCode)
            {
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateGuestDto>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditGuest(UpdateGuestDto guestDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(guestDto);
            StringContent cc = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseM = await client.PutAsync("https://localhost:7227/api/Guest", cc);

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("GuestIndex");
            }

            return View();
        }
    }
}
