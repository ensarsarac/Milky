using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.AboutBannerDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutBannerController : ControllerBase
    {
        private readonly IAboutBannerService _aboutBannerService;

        public AboutBannerController(IAboutBannerService aboutBannerService)
        {
            _aboutBannerService = aboutBannerService;
        }

        [HttpGet]
        public IActionResult AboutBannerList()
        {
            var values = _aboutBannerService.TGetList();
            var result = values.Select(x => new ResultAboutBannerDto
            {
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                AboutBannerId = x.AboutBannerId,
                Title = x.Title
            }).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateAboutBanner(CreateAboutBannerDto createAboutBannerDto)
        {
            _aboutBannerService.TInsert(new AboutBanner
            {
                Title = createAboutBannerDto.Title,
                ImageUrl = createAboutBannerDto.ImageUrl,
                Description = createAboutBannerDto.Description,
            });
            return Ok("Hakkımızda Banner alanı eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteAboutBanner(int id)
        {
            _aboutBannerService.TDelete(id);
            return Ok("Hakkımızda Banner alanı silindi");
        }
        [HttpPut]
        public IActionResult UpdateAboutBanner(UpdateAboutBannerDto updateAboutBannerDto)
        {
            var value = _aboutBannerService.TGetById(updateAboutBannerDto.AboutBannerId);
            value.Title = updateAboutBannerDto.Title;
            value.Description = updateAboutBannerDto.Description;
            value.ImageUrl = updateAboutBannerDto.ImageUrl;
            value.AboutBannerId = updateAboutBannerDto.AboutBannerId;
            _aboutBannerService.TUpdate(value);
            return Ok("Hakkımızda Banner alanı güncellendi.");
        }
        [HttpGet("GetAboutBanner")]
        public IActionResult GetAboutBanner(int id)
        {
            var value = _aboutBannerService.TGetById(id);
            var result = new ResultAboutBannerDto()
            {
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Title = value.Title,
                AboutBannerId = value.AboutBannerId
            };
            return Ok(result);
        }


    }
}
