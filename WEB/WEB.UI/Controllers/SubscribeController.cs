using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WEB_UI.Models;

namespace WEB_UI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SubscribeIndex()
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync("https://localhost:7227/api/Subscribe");

            if (responseM.IsSuccessStatusCode)
            {
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<SubscribeViewModel>>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddSubscribe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscribe(SubscribeViewModel subscribeViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(subscribeViewModel);
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseM = await client.PostAsync("https://localhost:7227/api/Subscribe", content);

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("SubscribeIndex");
            }

            return View();
        }

        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.DeleteAsync($"https://localhost:7227/api/Subscribe?id={id}");

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("SubscribeIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditSubscribe(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync($"https://localhost:7227/api/Subscribe/{id}");

            if (responseM.IsSuccessStatusCode)
            {
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<SubscribeViewModel>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditSubscribe(SubscribeViewModel subscribeViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(subscribeViewModel);
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseM = await client.PutAsync("https://localhost:7227/api/Subscribe", content);

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("SubscribeIndex");
            }

            return View();
        }
    }
}
