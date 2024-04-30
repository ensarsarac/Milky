using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.OpenHourDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _OpenHoursComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OpenHoursComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/OpenHour");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOpenHourDto>>(read);
                return View(values);
            }
            return View();
        }
    }
}
