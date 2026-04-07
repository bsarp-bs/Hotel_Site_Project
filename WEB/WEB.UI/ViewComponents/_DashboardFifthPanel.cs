using Microsoft.AspNetCore.Mvc;
using WEB_UI.UI_DTO.BookingDTOs;

namespace WEB_UI.ViewComponents
{
    public class _DashboardFifthPanel : ViewComponent
    {
        private readonly IHttpClientFactory _clientfactory;

        public _DashboardFifthPanel(IHttpClientFactory clientfactory)
        {
            _clientfactory = clientfactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientfactory.CreateClient();

            var value = await client.GetFromJsonAsync<List<ViewBookingDto>>("https://localhost:7227/api/Booking");

            return View(value);
        }
    }
}
