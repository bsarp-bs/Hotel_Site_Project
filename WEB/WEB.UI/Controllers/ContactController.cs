using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WEB_UI.Models;
using WEB_UI.UI_DTO.ContactDTOs;

namespace WEB_UI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ContactIndex()
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync("https://localhost:7227/api/Contact");

            if (responseM.IsSuccessStatusCode)
            {
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ViewContactDto>>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(InsertContactDto contactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(contactDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseM = await client.PostAsync("https://localhost:7227/api/Contact", stringContent);

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("ContactIndex");
            }

            return View();
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.DeleteAsync($"https://localhost:7227/api/Contact/{id}");

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("ContactIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync($"https://localhost:7227/api/Contact/{id}");

            if (responseM.IsSuccessStatusCode)
            {
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateContactDto>(jsondata);

                return View(value);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditContact(UpdateContactDto contactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(contactDto);
            StringContent cc = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseM = await client.PutAsync("https://localhost:7227/api/Contact", cc);

            if (responseM.IsSuccessStatusCode)
            {
                return RedirectToAction("ContactIndex");
            }

            return View();
        }

        public async Task<IActionResult> SendedMessagesIndex()
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                var value = await client.GetFromJsonAsync<List<SendedMessagesViewModel>>("https://localhost:7227/api/SendedMessages");
                return View(value ?? new List<SendedMessagesViewModel>());
            }
            catch
            {
                return View(new List<SendedMessagesViewModel>());
            }
        }

        [HttpGet]
        public IActionResult AddSendedMessages()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendedMessages(SendedMessagesViewModel sv)
        {
            if (!ModelState.IsValid)
            {
                return View(sv);
            }

            var client = _httpClientFactory.CreateClient();

            sv.SenderName = "Admin";
            sv.SenderMail = "admin@gmail.com";
            sv.MessageDate = DateTime.Now;
            sv.ReceviverName = "string";

            var response = await client.PostAsJsonAsync("https://localhost:7227/api/SendedMessages", sv);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SendedMessagesIndex");
            }
            else
            {
                return View(sv);
            }

        }

        [HttpGet]
        public async Task<IActionResult> EditSendedMessages(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseM = await client.GetAsync($"https://localhost:7227/api/SendedMessages/{id}");

            if (responseM.IsSuccessStatusCode)
            {
                var jsondata = await responseM.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<SendedMessagesViewModel>(jsondata);

                return View(value);
            }

            return View();
        }
    }
}
