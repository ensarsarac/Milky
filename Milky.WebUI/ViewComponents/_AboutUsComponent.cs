using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.AboutDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _AboutUsComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/About");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(read);
                return View(values.FirstOrDefault());
            }
            return View();
        }
    }
}
