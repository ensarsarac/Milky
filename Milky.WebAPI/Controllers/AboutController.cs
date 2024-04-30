using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.AboutDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetList();
            var result = values.Select(x => new ResultAboutDto()
            {
                AboutId=x.AboutId,
                Description=x.Description,
                ImageUrl1 = x.ImageUrl1,
                ImageUrl2 = x.ImageUrl2,
                ImageUrl3 = x.ImageUrl3,
                Services1 = x.Services1,
                Services1Icon = x.Services1Icon,
                Services2Icon =x.Services2Icon,
                Title = x.Title,
                Services1Description = x.Services1Description,
                Services2=x.Services2,
                Services2Description = x.Services2Description,
            }).ToList();

            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            _aboutService.TInsert(new About
            {
                Description = createAboutDto.Description,
                ImageUrl1 = createAboutDto.ImageUrl1,
                ImageUrl2 = createAboutDto.ImageUrl2,
                ImageUrl3 = createAboutDto.ImageUrl3,
                Services1 = createAboutDto.Services1,
                Services1Icon = createAboutDto.Services1Icon,
                Services2Icon = createAboutDto.Services2Icon,
                Title = createAboutDto.Title,
                Services1Description = createAboutDto.Services1Description,
                Services2 = createAboutDto.Services2,
                Services2Description = createAboutDto.Services2Description,
            });
            return Ok("Hakkımızda bilgileri eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Hakkımızda bilgileri silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _aboutService.TGetById(updateAboutDto.AboutId);
            value.Description = updateAboutDto.Description;
            value.ImageUrl1 = updateAboutDto.ImageUrl1;
            value.ImageUrl2 = updateAboutDto.ImageUrl2;
            value.ImageUrl3 = updateAboutDto.ImageUrl3;
            value.Services1 = updateAboutDto.Services1;
            value.Services1Icon = updateAboutDto.Services1Icon;
            value.Services2Icon = updateAboutDto.Services2Icon;
            value.Title = updateAboutDto.Title;
            value.Services1Description= updateAboutDto.Services1Description;
            value.Services2= updateAboutDto.Services2;
            value.Services2Description = updateAboutDto.Services2Description;
            _aboutService.TUpdate(value);
            return Ok("Hakkımızda bilgileri güncellendi.");
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            var result = new ResultAboutDto()
            {
                AboutId=value.AboutId,
                Description = value.Description,
                ImageUrl1 = value.ImageUrl1,
                ImageUrl2 = value.ImageUrl2,
                ImageUrl3 = value.ImageUrl3,
                Services1 = value.Services1,
                Services1Icon = value.Services1,
                Services2Icon = value.Services2Icon,
                Title = value.Title,
                Services1Description = value.Services1Description,
                Services2 = value.Services2,
                Services2Description = value.Services2Description,
            };
            return Ok(result);
        }
    }
}
