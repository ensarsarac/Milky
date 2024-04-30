using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents
{
	public class _UILayoutPageInfoComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
