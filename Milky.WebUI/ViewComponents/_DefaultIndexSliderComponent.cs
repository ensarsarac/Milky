using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.SliderDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _DefaultIndexSliderComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultIndexSliderComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Slider");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(read);
                return View(values);
            }
            return View();
        }
    }
}
