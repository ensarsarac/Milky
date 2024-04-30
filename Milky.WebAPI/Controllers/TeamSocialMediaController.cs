using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.TeamSocialMediaDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamSocialMediaController : ControllerBase
    {
        private readonly ITeamSocialMediaService _service;

        public TeamSocialMediaController(ITeamSocialMediaService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult TeamSocialMediaList()
        {
            var values = _service.TGetList();
            var result = values.Select(x => new ResultTeamSocialMediaDto()
            {
                Icon = x.Icon,
                Platform = x.Platform,
                TeamId = x.TeamId,
                TeamSocialMediaId = x.TeamSocialMediaId,
                Url = x.Url
            }).ToList();

            return Ok(result);
        }
        [HttpGet("TeamSocialMediaByTeamId/{id}")]
        public IActionResult TeamSocialMediaByTeamId(int id)
        {
            var values = _service.TGetTeamSocialMediaByTeamId(id);
            var result = values.Select(x => new ResultTeamSocialMediaDto()
            {
                Icon = x.Icon,
                Platform = x.Platform,
                TeamId = x.TeamId,
                TeamSocialMediaId = x.TeamSocialMediaId,
                Url = x.Url
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTeamSocialMedia(CreateTeamSocialMediaDto createTeamSocialMediaDto)
        {
            _service.TInsert(new TeamSocialMedia
            {
                Url = createTeamSocialMediaDto.Url,
                TeamId=createTeamSocialMediaDto.TeamId,
                Platform=createTeamSocialMediaDto.Platform,
                Icon=createTeamSocialMediaDto.Icon,
            });
            return Ok("Çalışan sosyal medya hesabı eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTeamSocialMedia(int id)
        {
            _service.TDelete(id);
            return Ok("Çalışan sosyal medya hesabı silindi");
        }
        [HttpPut]
        public IActionResult UpdateTeamSocialMedia(UpdateTeamSocialMediaDto updateTeamSocialMediaDto)
        {
            var value = _service.TGetById(updateTeamSocialMediaDto.TeamSocialMediaId);
            value.TeamId = updateTeamSocialMediaDto.TeamId;
            value.Url = updateTeamSocialMediaDto.Url;
            value.Icon = updateTeamSocialMediaDto.Icon;
            value.Platform = updateTeamSocialMediaDto.Platform;
            _service.TUpdate(value);
            return Ok("Çalışan sosyal medya hesabı güncellendi.");
        }
        [HttpGet("GetTeamSocialMedia")]
        public IActionResult GetTeamSocialMedia(int id)
        {
            var value = _service.TGetById(id);
            var result = new ResultTeamSocialMediaDto()
            {
                Platform = value.Platform,
                Icon = value.Icon,
                TeamId = value.TeamId,
                TeamSocialMediaId=value.TeamSocialMediaId,
                Url = value.Url,
            };
            return Ok(result);
        }
    }
}
