using Microsoft.AspNetCore.Mvc;
using WEB_UI.UI_DTO.BookingDTOs;

namespace WEB_UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BookingIndex(ViewBookingDto bookingdto)
        {
            var client = _httpClientFactory.CreateClient();

            try 
            {
                var response = await client.GetFromJsonAsync<List<ViewBookingDto>>("https://localhost:7227/api/Booking");
                return View(response ?? new List< ViewBookingDto>());
            }
            catch 
            {
                return View(new List<ViewBookingDto>());
            }
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7227/api/Booking/{id}");

            return RedirectToAction("SubscribeIndex");
        }

        public async Task<IActionResult> ApproveBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var booking = await client.GetFromJsonAsync<ViewBookingDto>($"https://localhost:7227/api/Booking/{id}");

            booking?.Status = "Onaylandı";

            var response = await client.PutAsJsonAsync("https://localhost:7227/api/Booking", booking);

            return RedirectToAction("BookingIndex");
        }

        public async Task<IActionResult> OnHoldBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var booking = await client.GetFromJsonAsync<ViewBookingDto>($"https://localhost:7227/api/Booking/{id}");

            booking?.Status = "Beklemede";

            var response = await client.PutAsJsonAsync("https://localhost:7227/api/Booking", booking);

            return RedirectToAction("BookingIndex");
        }

    }
}
