using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json.Linq;
using WEB_UI.UI_DTO.LoginDTOs;
using WEB_UI.UI_DTO.RoomDTOs;

namespace WEB_UI.Controllers
{
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> RoomIndex()
        {
            var client = _httpClientFactory.CreateClient();
            try
            {
                var value = await client.GetFromJsonAsync<List<ViewRoomDto>>("https://localhost:7227/api/Room");
                return View(value ?? new List<ViewRoomDto>());

            } catch
            {
                return View(new List<ViewRoomDto>());
            }
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(InsertRoomDto _room)
        {
            if (!ModelState.IsValid)
            {
                return View(_room);
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7227/api/Room", _room);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("RoomIndex");
            }
            else
            {
                return View(_room);
            }

        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.DeleteAsync($"https://localhost:7227/api/Room/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("RoomIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditRoom(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<ViewRoomDto>($"https://localhost:7227/api/Room/{id}");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditRoom(ViewRoomDto _room)
        {

            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync("https://localhost:7227/api/Room", _room);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("RoomIndex");
            }
            else
            {
                return View(_room);
            }

        }

    }
}
