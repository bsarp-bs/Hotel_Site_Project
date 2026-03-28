using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.ViewComponents
{
    public class _VideoP : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
