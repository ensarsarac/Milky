using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.TeamDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _TeamComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TeamComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Team");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(read);
                return View(values);
            }
            return View();
        }
    }
}
