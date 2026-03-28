using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }

        public PartialViewResult HeadPartial() 
        {
            return PartialView();
        }
        public PartialViewResult PreLoaderPartial() 
        {
            return PartialView();
        }
        public PartialViewResult NavHeaderPartial() 
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial() 
        {
            return PartialView();
        }

        public PartialViewResult SidebarPartial() 
        {
            return PartialView();
        }
    }
}
