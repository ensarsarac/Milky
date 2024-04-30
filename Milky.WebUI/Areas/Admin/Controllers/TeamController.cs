﻿using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Areas.Admin.Dtos.TeamDtos;
using Newtonsoft.Json;
using System.Text;

namespace Milky.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Team");
            var readData = await res.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<List<ResultTeamDtos>>(readData);
            return View(jsonData);
        }
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7226/api/Team?id=" + id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDtos createTeamDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTeamDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("https://localhost:7226/api/Team", content);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createTeamDto);
        }
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Team/GetTeam?id=" + id);
            if (res.IsSuccessStatusCode)
            {
                var readData = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTeamDtos>(readData);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDtos updateTeam)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTeam);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("https://localhost:7226/api/Team", content);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View(updateTeam);
        }
    }
}
