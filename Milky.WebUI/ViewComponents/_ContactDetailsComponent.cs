using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.ContactInfoDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _ContactDetailsComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactDetailsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/ContactInfo");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactInfoDto>>(read);
                return View(values.FirstOrDefault());
            }
            return View();
        }
    }
}
