using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _FeatureStatisticComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FeatureStatisticComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            #region customercount
            var res = await client.GetAsync("https://localhost:7226/api/Statistic/CustomerCount");
            var readData = await res.Content.ReadAsStringAsync();
            ViewBag.customercount= JsonConvert.DeserializeObject<int>(readData);
            #endregion
            #region totalanimals
            var res2 = await client.GetAsync("https://localhost:7226/api/Statistic/TotalAnimals");
            var readData2 = await res2.Content.ReadAsStringAsync();
            ViewBag.animalcount = JsonConvert.DeserializeObject<int>(readData2);
            #endregion
            #region experience
            var res3 = await client.GetAsync("https://localhost:7226/api/Statistic/Experience\r\n");
            var readData3 = await res3.Content.ReadAsStringAsync();
            ViewBag.experience = JsonConvert.DeserializeObject<int>(readData3);
            #endregion
            #region experience
            var res4 = await client.GetAsync("https://localhost:7226/api/Statistic/Award");
            var readData4 = await res4.Content.ReadAsStringAsync();
            ViewBag.awardcount = JsonConvert.DeserializeObject<int>(readData4);
            #endregion
            return View();
        }
    }
}
