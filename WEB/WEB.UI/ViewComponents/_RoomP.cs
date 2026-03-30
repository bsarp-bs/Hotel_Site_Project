using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEB_UI.UI_DTO.RoomDTOs;

namespace WEB_UI.ViewComponents
{
    public class _RoomP : ViewComponent
    {
        private readonly IHttpClientFactory _httpclient;

        public _RoomP(IHttpClientFactory client)
        {
            _httpclient = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpclient.CreateClient();

            try
            {
                var value = await client.GetFromJsonAsync<List<ViewRoomDto>>("https://localhost:7227/api/Room");

                return View(value ?? new List<ViewRoomDto>());
            }
            catch
            {
                return View(new List<ViewRoomDto>());
            }


        }
    }
}
