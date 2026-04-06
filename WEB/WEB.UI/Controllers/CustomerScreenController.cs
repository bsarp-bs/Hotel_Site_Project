using Microsoft.AspNetCore.Mvc;
using WEB_UI.UI_DTO.BookingDTOs;
using WEB_UI.UI_DTO.DutyDTOs;
using WEB_UI.UI_DTO.SubscribeDTOs;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WEB_UI.Models;
using WEB_UI.UI_DTO.ContactDTOs;
using Microsoft.AspNetCore.Authorization;

namespace WEB_UI.Controllers
{
    [AllowAnonymous]
    public class CustomerScreenController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerScreenController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult CustomerScreenIndex()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddNewsletter()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewsletter(InsertSubscribeDto _subsdto)
        {
            if (!ModelState.IsValid)
            {
                return View(_subsdto);
            }

            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync("https://localhost:7227/api/Subscribe", _subsdto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerScreenIndex");
            }

            ModelState.AddModelError(string.Empty, "Görev eklenirken bir hata oluştu.");
            return View(_subsdto);

        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(InsertBookingDto bookingdto)
        {
            if (!ModelState.IsValid)
            {
                TempData["BookingError"] = "Lutfen form alanlarini kontrol edin.";
                return RedirectToAction("CustomerScreenIndex");
            }

            var client = _httpClientFactory.CreateClient();
            bookingdto.Status = "Onay Bekliyor";

            var response = await client.PostAsJsonAsync("https://localhost:7227/api/Booking", bookingdto);
            
            if (response.IsSuccessStatusCode) 
            {
                TempData["BookingSuccess"] = "Oda talebiniz alindi.";
                return RedirectToAction("CustomerScreenIndex");
            }

            var responseText = await response.Content.ReadAsStringAsync();
            TempData["BookingError"] = $"Oda tutarken hata olustu. Kod: {(int)response.StatusCode}. Detay: {responseText}";
            return RedirectToAction("CustomerScreenIndex");
        }

        [HttpGet]
        public PartialViewResult AddContact() 
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(InsertContactDto _contact) 
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CustomerScreenIndex");
            }

            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync("https://localhost:7227/api/Contact", _contact);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerScreenIndex");
            }

            ModelState.AddModelError(string.Empty, "Mail yollarken hata oluştu.");
            return View(_contact);
        }
    }
}
