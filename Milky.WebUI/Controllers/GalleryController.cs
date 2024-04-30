using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
