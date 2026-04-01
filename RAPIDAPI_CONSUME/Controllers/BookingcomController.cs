using Microsoft.AspNetCore.Mvc;
using RAPIDAPI_CONSUME.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RAPIDAPI_CONSUME.Controllers
{
    public class BookingcomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public BookingcomController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var rapidApiKey = _configuration["RapidApi:Key"];
            var rapidApiHost = _configuration["RapidApi:Host"] ?? "booking-com.p.rapidapi.com";

            if (string.IsNullOrWhiteSpace(rapidApiKey))
            {
                ViewBag.ErrorMessage = "RapidAPI key tanimlanmamis. appsettings.json icine RapidApi:Key eklemelisin.";
                return View(new List<BookingcomModel>());
            }

            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://booking-com.p.rapidapi.com/v1/attractions/availability?date=2026-09-18&locale=en-gb&attraction_id=PRFZkGSVnM5d&currency=AED");

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("x-rapidapi-key", rapidApiKey);
            request.Headers.Add("x-rapidapi-host", rapidApiHost);

            try
            {
                using var response = await client.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"RapidAPI istegi basarisiz oldu. Kod: {(int)response.StatusCode}. Detay: {body}";
                    return View(new List<BookingcomModel>());
                }

                var values = JsonSerializer.Deserialize<List<BookingcomModel>>(body, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return View(values ?? new List<BookingcomModel>());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Booking.com verisi alinirken hata olustu: {ex.Message}";
                return View(new List<BookingcomModel>());
            }
        }
    }
}
