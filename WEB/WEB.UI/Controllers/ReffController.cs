using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WEB_UI.Models;

namespace WEB_UI.Controllers
{
    public class ReffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> ReffIndex()
        {
            var client = _httpClientFactory.CreateClient();

            var responseM = await client.GetAsync("https://localhost:7227/api/Reff");

            if (responseM.IsSuccessStatusCode)
            { 
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ReffViewModel>>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddReff() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReff(ReffViewModel reffmodel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(reffmodel);
            StringContent content = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responseM = await client.PostAsync("https://localhost:7227/api/Reff", content);

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("ReffIndex");
            }

            return View();
        }

        public async Task<IActionResult> DeleteReff(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.DeleteAsync($"https://localhost:7227/api/Reff/{id}");

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("ReffIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditReff(int id) 
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync($"https://localhost:7227/api/Reff/{id}");

            if (responseM.IsSuccessStatusCode)
            {
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ReffViewModel>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditReff(ReffViewModel reffmodel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(reffmodel);
            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responseM = await client.PutAsync("https://localhost:7227/api/Reff", stringContent);
            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("ReffIndex");
            }
            return View();
        }

    }
}
