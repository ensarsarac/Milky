using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.WhyUsDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _FeatureComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FeatureComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/WhyUs");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhyUsDto>>(read);
                return View(values.FirstOrDefault());
            }
            return View();
        }
    }
}
