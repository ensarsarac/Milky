using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.RegisterDtos;
using Milky.WebUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace Milky.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var read = JsonConvert.SerializeObject(createRegisterDto);
            var content = new StringContent(read,Encoding.UTF8,"application/json");
            var res = await client.PostAsync("https://localhost:7226/api/Auth/Register", content);
            if(res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                var readData = await res.Content.ReadAsStringAsync();
                ViewBag.error = JsonConvert.DeserializeObject<List<ErrorViewModel>>(readData);
                return View();
            }
        }
    }
}
