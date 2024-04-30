using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.WhyUsDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhyUsController : ControllerBase
    {
        private readonly IWhyUsService _whyUsService;

        public WhyUsController(IWhyUsService whyUsService)
        {
            _whyUsService = whyUsService;
        }
        [HttpGet]
        public IActionResult WhyUsList()
        {
            var values = _whyUsService.TGetList();
            var result = values.Select(x => new ResultWhyUsDto
            {
                Title = x.Title,
                Article1 = x.Article1,
                Article2 = x.Article2,
                Article3 = x.Article3,  
                Description = x.Description,
                WhyUsId = x.WhyUsId
            }).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateWhyUs(CreateWhyUsDto createWhyUsDto)
        {
            _whyUsService.TInsert(new WhyUs
            {
                Title=createWhyUsDto.Title,
                Description=createWhyUsDto.Description,
                Article3 = createWhyUsDto.Article3,
                Article2 = createWhyUsDto.Article2,
                Article1 = createWhyUsDto.Article1,
            });
            return Ok("Neden biz alanı eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteWhyUs(int id)
        {
            _whyUsService.TDelete(id);
            return Ok("Neden biz alanı silindi");
        }
        [HttpPut]
        public IActionResult UpdateWhyUs(UpdateWhyUsDto updateWhyUsDto)
        {
            var value = _whyUsService.TGetById(updateWhyUsDto.WhyUsId);
            value.Description= updateWhyUsDto.Description;
            value.Article1 = updateWhyUsDto.Article1;
            value.Article2 = updateWhyUsDto.Article2;
            value.Article3 = updateWhyUsDto.Article3;
            value.Title = updateWhyUsDto.Title;
            _whyUsService.TUpdate(value);
            return Ok("Neden biz alanı güncellendi.");
        }
        [HttpGet("GetWhyUs")]
        public IActionResult GetWhyUs(int id)
        {
            var value = _whyUsService.TGetById(id);
            var result = new ResultWhyUsDto()
            {
                Title = value.Title,
                Article3 = value.Article3,
                Article2 = value.Article2,
                Article1 = value.Article1,
                Description = value.Description,
                WhyUsId = value.WhyUsId
            };
            return Ok(result);
        }
    }
}
