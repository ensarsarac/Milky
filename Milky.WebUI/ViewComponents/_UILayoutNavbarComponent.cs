using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents
{
	public class _UILayoutNavbarComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
