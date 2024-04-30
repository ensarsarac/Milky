using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.NewsletterDtos;

namespace Milky.WebUI.ViewComponents
{
    public class _FooterNewsletterComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new CreateNewsletterDto());
        }
    }
}
