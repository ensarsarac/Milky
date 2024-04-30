using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.SocialMediaDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaService.TGetList();
            var result = values.Select(x => new ResultSocialMediaDto()
            {
                Icon = x.Icon,
                Platform = x.Platform,
                SocialMediaId = x.SocialMediaId,
                Url = x.Url
            }).ToList();

            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TInsert(new SocialMedia
            {
                Url = createSocialMediaDto.Url,
                Icon = createSocialMediaDto.Icon,
                Platform=createSocialMediaDto.Platform,
            });
            return Ok("Sosyal medya hesabı eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            _socialMediaService.TDelete(id);
            return Ok("Sosyal medya hesabı silindi");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _socialMediaService.TGetById(updateSocialMediaDto.SocialMediaId);
            value.Platform = updateSocialMediaDto.Platform;
            value.Icon=updateSocialMediaDto.Icon;
            value.Url= updateSocialMediaDto.Url;
            _socialMediaService.TUpdate(value);
            return Ok("Sosyal medya hesabı güncellendi.");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            var result = new ResultSocialMediaDto()
            {
                Url= value.Url,
                Icon= value.Icon,
                Platform = value.Platform,
                SocialMediaId=value.SocialMediaId
            };
            return Ok(result);
        }
    }
}
