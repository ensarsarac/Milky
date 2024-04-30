using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Milky.EntityLayer.Concrete;
using Milky.WebUI.Dtos.LoginDtos;
using Milky.WebUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace Milky.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(IHttpClientFactory httpClientFactory, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var read = JsonConvert.SerializeObject(createLoginDto);
            var content = new StringContent(read, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("https://localhost:7226/api/Auth/Login", content);
            if (res.IsSuccessStatusCode)
            {
                var user = await _userManager.FindByEmailAsync(createLoginDto.Email);
                await _signInManager.PasswordSignInAsync(user, createLoginDto.Password,false,false);
                return RedirectToAction("Index", "Default");
            }
            else
            {
                var readData = await res.Content.ReadAsStringAsync();
                ViewBag.Loginerror = JsonConvert.DeserializeObject<LoginErrorViewModel>(readData);
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Auth/Logout");
            if (res.IsSuccessStatusCode)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
