using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.ViewComponents
{
    public class _AboutP : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
