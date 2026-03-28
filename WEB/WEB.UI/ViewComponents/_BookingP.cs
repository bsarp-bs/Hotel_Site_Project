using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.ViewComponents
{
    public class _BookingP : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
