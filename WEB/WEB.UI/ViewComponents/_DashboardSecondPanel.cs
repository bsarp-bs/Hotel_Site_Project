using Microsoft.AspNetCore.Mvc;
using WEB_UI.UI_DTO.RoomDTOs;

namespace WEB_UI.ViewComponents
{
    public class _DashboardSecondPanel : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardSecondPanel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpClientFactory.CreateClient();

            var value = await client.GetFromJsonAsync<List<ViewRoomDto>>("https://localhost:7227/api/Room");

            return View(value);
        }
    }
}
