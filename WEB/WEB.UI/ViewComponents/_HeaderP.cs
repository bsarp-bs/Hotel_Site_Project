using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.ViewComponents
{
    public class _HeaderP : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
