using Microsoft.AspNetCore.Mvc;
using WEB_UI.UI_DTO.TeamDTOs;

namespace WEB_UI.ViewComponents
{
    public class _DashboardThirdPanel : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardThirdPanel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<List<TeamDto>>("https://localhost:7227/api/Team");

            return View(response);
        }
    }
}
