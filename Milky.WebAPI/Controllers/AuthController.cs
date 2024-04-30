using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Milky.DtoLayer.AuthDtos;
using Milky.EntityLayer.Concrete;
using Milky.WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateRegisterDto createRegisterDto)
        {
            if(ModelState.IsValid)
            {
                if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
                {
                    var user = new AppUser()
                    {
                        Name = createRegisterDto.Name,
                        Email = createRegisterDto.Email,
                        Surname = createRegisterDto.Surname,
                        UserName = createRegisterDto.UserName,
                    };
                    var createUser = await _userManager.CreateAsync(user, createRegisterDto.Password);
                    if (createUser.Succeeded)
                    {
                        //await _userManager.AddToRoleAsync(user, "Member");
                        return Ok("Kullanıcı başarıyla oluşturuldu.");
                    }
                    else
                    {
                        foreach (var item in createUser.Errors)
                        {
                            ModelState.AddModelError(string.Empty, item.Description);
                        }
                        return BadRequest(createUser.Errors);
                    }
                }
            }
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(CreateLoginDto createLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(createLoginDto.Email);
            var loginuser = await _signInManager.PasswordSignInAsync(user.UserName, createLoginDto.Password, false, false);
            if(loginuser.Succeeded)
            {
                return Ok(loginuser);
            }
            else
            {
                var result = new LoginErrorViewModel()
                {
                    Error = "Kullanıcı adı veya şifre hatalı!!"
                };
                return BadRequest(result);
            }
        }
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Çıkış yapıldı");
        }
    }
}
