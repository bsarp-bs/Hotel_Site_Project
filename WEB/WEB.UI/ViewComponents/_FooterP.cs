using Microsoft.AspNetCore.Mvc;

namespace WEB_UI.ViewComponents
{
    public class _FooterP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
