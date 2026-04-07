using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult DashboardIndex()
        {
            return View();
        }
    }
}
