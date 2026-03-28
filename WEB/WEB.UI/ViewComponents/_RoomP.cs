using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.ViewComponents
{
    public class _RoomP : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
