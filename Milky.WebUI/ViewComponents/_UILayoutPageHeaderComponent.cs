using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents
{
    public class _UILayoutPageHeaderComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
