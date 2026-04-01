using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB_UI.Models;

namespace WEB_UI.ViewComponents
{
    public class _WeatherP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public _WeatherP(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();

            var apiKey = _configuration["RapidApi:Key"];
            var apiHost = _configuration["RapidApi:Host"];

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city?city=istanbul&lang=EN"),
                Headers =
                            {
                                { "x-rapidapi-key", apiKey},
                                { "x-rapidapi-host", apiHost},
                            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();

                var value = JsonConvert.DeserializeObject<RapidApiWeatherModel>(body);

                return View(value);
            }
        }
    }
}
