using Microsoft.AspNetCore.Mvc;
using WEB_UI.UI_DTO.DutyDTOs;
using WEB_UI.UI_DTO.SubscribeDTOs;

namespace WEB_UI.Controllers
{
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
    }
}
