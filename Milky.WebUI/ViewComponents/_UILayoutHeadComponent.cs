using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.ViewComponents
{
	public class _UILayoutHeadComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
