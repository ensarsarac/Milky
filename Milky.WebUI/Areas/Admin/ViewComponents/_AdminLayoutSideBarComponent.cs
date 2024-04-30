using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutSideBarComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
