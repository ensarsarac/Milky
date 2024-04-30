using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.ServiceDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _ServiceComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Service");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(read);
                return View(values);
            }
            return View();
        }
    }
}
