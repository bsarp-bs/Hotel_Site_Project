using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.ViewComponents
{
    public class _ServiceP : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
