using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Areas.Admin.Dtos.TeamDtos;
using Milky.WebUI.Areas.Admin.Dtos.TeamSocialMediaDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Milky.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamSocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeamSocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/TeamSocialMedia/TeamSocialMediaByTeamId/"+id);
            var readData = await res.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTeamSocialMediaDto>>(readData);

            var res2 = await client.GetAsync("https://localhost:7226/api/Team/GetTeam?id=" + id);
            var readData2 = await res2.Content.ReadAsStringAsync();
            ViewBag.employee = JsonConvert.DeserializeObject<ResultTeamDtos>(readData2);

            return View(values);
        }
        public IActionResult CreateTeamSocialMedia(int id)
        {
            TempData["id"] = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeamSocialMedia(CreateTeamSocialMediaDto createTeamSocialMediaDto)
        {
            var employeeid = (int)TempData["id"];
            createTeamSocialMediaDto.TeamId= employeeid;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTeamSocialMediaDto);
            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7226/api/TeamSocialMedia", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new {id=employeeid});
            }
            return View(createTeamSocialMediaDto);
        }
        public async Task<IActionResult> DeleteTeamSocialMedia(int id)
        {
            var employeeid = (int)TempData["id"];
            var client = _httpClientFactory.CreateClient();
            var res = await client.DeleteAsync("https://localhost:7226/api/TeamSocialMedia?id=" + id);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { id = employeeid });
            }
            return View();
        }
        public async Task<IActionResult> UpdateTeamSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/TeamSocialMedia/GetTeamSocialMedia?id=" + id);
            if (res.IsSuccessStatusCode)
            {
                var readData = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTeamSocialMediaDto>(readData);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeamSocialMedia(UpdateTeamSocialMediaDto updateTeamSocialMediaDto)
        {
            var employeeid = (int)TempData["id"];
            var client = _httpClientFactory.CreateClient();
            var jsonData =JsonConvert.SerializeObject(updateTeamSocialMediaDto);
            var content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var res = await client.PutAsync("https://localhost:7226/api/TeamSocialMedia",content);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { id = employeeid });
            }
            return View(updateTeamSocialMediaDto);

        }
    }
}
