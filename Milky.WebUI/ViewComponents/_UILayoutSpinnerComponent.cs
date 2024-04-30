using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents
{
    public class _UILayoutSpinnerComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
