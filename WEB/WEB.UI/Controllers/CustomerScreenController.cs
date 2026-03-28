using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.Controllers
{
    public class CustomerScreenController : Controller
    {
        public IActionResult CustomerScreenIndex()
        {
            return View();
        }
    }
}
