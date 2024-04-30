using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.NewsletterDtos;
using Newtonsoft.Json;
using System.Text;

namespace Milky.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewsletter(CreateNewsletterDto createNewsletterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNewsletterDto);
            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var res = await client.PostAsync("https://localhost:7226/api/Newsletter", content);
            if(res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
