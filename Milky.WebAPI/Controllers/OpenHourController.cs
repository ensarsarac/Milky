using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.OpenHourDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenHourController : ControllerBase
    {
        private readonly IOpenHourService _openHourService;

        public OpenHourController(IOpenHourService openHourService)
        {
            _openHourService = openHourService;
        }
        [HttpGet]
        public IActionResult OpenHourList()
        {
            var values = _openHourService.TGetList();
            var result = values.Select(x => new ResultOpenHourDto
            {
                Description = x.Description,
                OpenHourId = x.OpenHourId,
                Title=x.Title,
            }).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateOpenHour(CreateOpenHourDto createOpenHourDto)
        {
            _openHourService.TInsert(new OpenHour
            {
               Title = createOpenHourDto.Title,
               Description= createOpenHourDto.Description,
            });
            return Ok("Çalışma saatleri eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteOpenHour(int id)
        {
            _openHourService.TDelete(id);
            return Ok("Çalışma saatleri silindi");
        }
        [HttpPut]
        public IActionResult UpdateOpenHour(UpdateOpenHourDto updateOpenHourDto)
        {
            var value = _openHourService.TGetById(updateOpenHourDto.OpenHourId);
            value.Description = updateOpenHourDto.Description;
            value.Title = updateOpenHourDto.Title;
            value.OpenHourId = updateOpenHourDto.OpenHourId;
            _openHourService.TUpdate(value);
            return Ok("Çalışma saatleri güncellendi.");
        }
        [HttpGet("GetOpenHour")]
        public IActionResult GetOpenHour(int id)
        {
            var value = _openHourService.TGetById(id);
            var result = new ResultOpenHourDto()
            {
                OpenHourId = value.OpenHourId,
                Title = value.Title,
                Description = value.Description,
            };
            return Ok(result);
        }
    }
}
