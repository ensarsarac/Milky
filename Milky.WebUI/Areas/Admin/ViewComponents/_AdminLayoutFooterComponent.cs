using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutFooterComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
