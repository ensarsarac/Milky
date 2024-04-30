using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents
{
	public class _UILayoutScriptsComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
