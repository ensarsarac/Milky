using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.GalleryDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _GalleryComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GalleryComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Gallery");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGalleryDto>>(read);
                return View(values);
            }
            return View();
        }
    }
}
