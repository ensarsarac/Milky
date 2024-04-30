using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.BannerDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _BannerComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BannerComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/AboutBanner");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(read);
                return View(values);
            }
            return View();
        }
    }
}
