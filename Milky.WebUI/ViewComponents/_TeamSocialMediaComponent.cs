using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.BannerDtos;
using Milky.WebUI.Dtos.TeamSocialMediaDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _TeamSocialMediaComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TeamSocialMediaComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/TeamSocialMedia/TeamSocialMediaByTeamId/"+id);
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeamSocialMediaDto>>(read);
                return View(values);
            }
            return View();
        }
    }
}
