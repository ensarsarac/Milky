using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents
{
	public class _UILayoutSubFooterComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
