using Microsoft.AspNetCore.Mvc;
using WEB_UI.UI_DTO.ReffDTOs;

namespace WEB_UI.ViewComponents
{
    public class _TestimonialP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();
            try 
            {
                var value = await client.GetFromJsonAsync<List<ReffDto>>("https://localhost:7227/api/Reff");
                return View(value ?? new List<ReffDto>());
            }
            catch 
            {
                return View(new List<ReffDto>());
            }
        }
    }
}
