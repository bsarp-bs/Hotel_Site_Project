using Microsoft.AspNetCore.Mvc;
using WEB_UI.UI_DTO.DutyDTOs;

namespace WEB_UI.ViewComponents
{
    public class _ServiceP : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceP(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();

            try 
            {
                var value = await client.GetFromJsonAsync<List<ViewDutyDto>>("https://localhost:7227/api/Duty");

                return View(value ?? new List<ViewDutyDto>());
            }
            catch 
            {
                return View(new List<ViewDutyDto>());
            }
          
        }
    }
}
