using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.TeamDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet]
        public IActionResult TeamList()
        {
            var values = _teamService.TGetList();
            var result = values.Select(x => new ResultTeamDto
            {
                NameSurname=x.NameSurname,
                ImageUrl = x.ImageUrl,
                TeamId = x.TeamId,
                Title = x.Title
            }).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateTeam(CreateTeamDto createTeamDto)
        {
            _teamService.TInsert(new Team
            {
                Title = createTeamDto.Title,
                ImageUrl = createTeamDto.ImageUrl,
                NameSurname = createTeamDto.NameSurname,
                
            });
            return Ok("Çalışan eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTeam(int id)
        {
            _teamService.TDelete(id);
            return Ok("Çalışan silindi");
        }
        [HttpPut]
        public IActionResult UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            var value = _teamService.TGetById(updateTeamDto.TeamId);
            value.Title = updateTeamDto.Title;
            value.NameSurname= updateTeamDto.NameSurname;
            value.ImageUrl = updateTeamDto.ImageUrl;
            value.TeamId = updateTeamDto.TeamId;
            _teamService.TUpdate(value);
            return Ok("Çalışan güncellendi.");
        }
        [HttpGet("GetTeam")]
        public IActionResult GetTeam(int id)
        {
            var value = _teamService.TGetById(id);
            var result = new ResultTeamDto()
            {
                NameSurname=value.NameSurname,
                ImageUrl = value.ImageUrl,
                Title = value.Title,
                TeamId = value.TeamId
            };
            return Ok(result);
        }
    }
}
