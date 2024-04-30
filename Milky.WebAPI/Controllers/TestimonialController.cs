using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.TestimonialDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetList();
            var result = values.Select(x => new ResultTestimonialDto
            {
                ImageUrl = x.ImageUrl,
                ClientName = x.ClientName,
                Comment=x.Comment,
                TestimonialId = x.TestimonialId,
                Title = x.Title
            }).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TInsert(new Testimonial
            {
                Title = createTestimonialDto.Title,
                ImageUrl = createTestimonialDto.ImageUrl,
                Comment = createTestimonialDto.Comment,
                ClientName= createTestimonialDto.ClientName,
            });
            return Ok("Müşteri yorumu eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Müşteri yorumu silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _testimonialService.TGetById(updateTestimonialDto.TestimonialId);
            value.Comment = updateTestimonialDto.Comment;
            value.Title = updateTestimonialDto.Title;
            value.ImageUrl= updateTestimonialDto.ImageUrl;
            value.ClientName = updateTestimonialDto.ClientName;
            value.TestimonialId = updateTestimonialDto.TestimonialId;
            _testimonialService.TUpdate(value);
            return Ok("Müşteri yorumu güncellendi.");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            var result = new ResultTestimonialDto()
            {
                TestimonialId = value.TestimonialId,
                ClientName = value.ClientName,
                ImageUrl = value.ImageUrl,
                Title = value.Title,
                Comment=value.Comment,
            };
            return Ok(result);
        }
    }
}
