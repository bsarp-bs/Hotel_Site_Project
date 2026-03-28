using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.ViewComponents
{
    public class _TeamP : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
