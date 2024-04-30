using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.SliderDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _sliderService.TGetList();
            var result = values.Select(x => new ResultSliderDto
            {
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                SliderId = x.SliderId,
                Title = x.Title
            }).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            _sliderService.TInsert(new Slider
            {
                Title = createSliderDto.Title,
                ImageUrl=createSliderDto.ImageUrl,
                Description = createSliderDto.Description,
            });
            return Ok("Slider eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteSlider(int id)
        {
            _sliderService.TDelete(id);
            return Ok("Slider silindi");
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var value = _sliderService.TGetById(updateSliderDto.SliderId);
            value.Title = updateSliderDto.Title;
            value.Description = updateSliderDto.Description;
            value.ImageUrl = updateSliderDto.ImageUrl;
            value.SliderId = updateSliderDto.SliderId;
            _sliderService.TUpdate(value);
            return Ok("Slider güncellendi.");
        }
        [HttpGet("GetSlider")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            var result = new ResultSliderDto()
            {
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Title = value.Title,
                SliderId = value.SliderId
            };
            return Ok(result);
        }
    }
}
