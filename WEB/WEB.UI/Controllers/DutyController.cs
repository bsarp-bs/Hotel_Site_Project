using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WEB_UI.UI_DTO.DutyDTOs;

namespace WEB_UI.Controllers
{
    public class DutyController : Controller
    {
        
        private readonly IHttpClientFactory _httpClientFactory;

        public DutyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> DutyIndex()
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync("https://localhost:7227/api/Duty");
            if (responseM.IsSuccessStatusCode)
            { 
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ViewDutyDto>>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddDuty()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDuty(InsertDutyDto genduty)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(genduty);
            StringContent stringContent = new StringContent(json, Encoding.UTF8,"application/json");
            var responseM = await client.PostAsync("https://localhost:7227/api/Duty", stringContent);
            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("DutyIndex");
            }

            return View();

        }

        public async Task<IActionResult> DeleteDuty(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.DeleteAsync($"https://localhost:7227/api/Duty/{id}");

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("DutyIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditDuty(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsem = await client.GetAsync($"https://localhost:7227/api/Duty/{id}");

            if (responsem.IsSuccessStatusCode)
            { 
                var jsondata =await responsem.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateDutyDto>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditDuty(UpdateDutyDto genduty) 
        { 
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(genduty);
            StringContent cc = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responseM = await client.PutAsync("https://localhost:7227/api/Duty", cc);

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("DutyIndex");
            }
            return View();

        }
        
    }
}
