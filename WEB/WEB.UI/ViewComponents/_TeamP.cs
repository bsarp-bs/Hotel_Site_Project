using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WEB_UI.UI_DTO.TeamDTOs;

namespace WEB_UI.ViewComponents
{
    public class _TeamP : ViewComponent
    {
        private readonly IHttpClientFactory _httpclient;

        public _TeamP(IHttpClientFactory httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var client = _httpclient.CreateClient();

            try 
            {
                var value = await client.GetFromJsonAsync<List<TeamDto>>("https://localhost:7227/api/Team");
                return View(value ?? new List<TeamDto>());
            }
            catch 
            {
                return View(new List<TeamDto>());
            }

        }
    }
}
