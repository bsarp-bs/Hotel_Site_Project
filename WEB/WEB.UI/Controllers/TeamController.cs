using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB_UI.Models;
using System.Text;

namespace WEB_UI.Controllers
{
    public class TeamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TeamIndex()
        {
            var client = _httpClientFactory.CreateClient();

            var responseM = await client.GetAsync("https://localhost:7227/api/Team");

            if (responseM.IsSuccessStatusCode)
            {
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsondata);
                return View(value);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddTeam() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddTeam(StaffViewModel AddModel)
        {
            var client = _httpClientFactory.CreateClient();

            var jsondata = JsonConvert.SerializeObject(AddModel);

            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");

            var responseM = await client.PostAsync("https://localhost:7227/api/Team", content);

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamIndex");
            }

            return View();
        }


        public async Task<IActionResult> DeleteTeam(int id)
        {
            var client = _httpClientFactory.CreateClient ();

            var responseM = await client.DeleteAsync($"https://localhost:7227/api/Team/{id}");

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditTeam(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseM = await client.GetAsync($"https://localhost:7227/api/Team/{id}");

            if (responseM.IsSuccessStatusCode)
            { 
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<StaffViewModel>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditTeam(StaffViewModel editmodel)
        {
            var client = _httpClientFactory.CreateClient();

            var jsondata = JsonConvert.SerializeObject(editmodel);

            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");

            var responseM = await client.PutAsync("https://localhost:7227/api/Team", content);

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamIndex");
            }

            return View();

        }
    }
}
