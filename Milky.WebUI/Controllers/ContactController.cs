using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.MessageDtos;
using Newtonsoft.Json;
using System.Text;

namespace Milky.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.Date=DateTime.Now;
            var client = _httpClientFactory.CreateClient(); 
            var jsondata = JsonConvert.SerializeObject(createMessageDto);
            var content = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var res = await client.PostAsync("https://localhost:7226/api/Message",content);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return RedirectToAction("Index");
        }
    }
}
