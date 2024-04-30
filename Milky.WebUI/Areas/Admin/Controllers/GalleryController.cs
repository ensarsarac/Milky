using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Areas.Admin.Dtos.GalleryDtos;
using Newtonsoft.Json;
using System.Text;

namespace Milky.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GalleryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Gallery");
            var readData = await res.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<List<ResultGalleryDto>>(readData);
            return View(jsonData);
        }
        public async Task<IActionResult> DeleteGallery(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7226/api/Gallery?id=" + id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateGallery(CreateGalleryDto createGalleryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createGalleryDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("https://localhost:7226/api/Gallery", content);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createGalleryDto);
        }
        public async Task<IActionResult> UpdateGallery(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Gallery/GetGallery?id=" + id);
            if (res.IsSuccessStatusCode)
            {
                var readData = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGalleryDto>(readData);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGallery(UpdateGalleryDto updateGallery)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateGallery);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("https://localhost:7226/api/Gallery", content);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View(updateGallery);
        }
    }
}
