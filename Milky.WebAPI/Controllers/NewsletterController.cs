using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.NewsletterDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterService _service;

        public NewsletterController(INewsletterService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult NewsletterList()
        {
            var values = _service.TGetList();
            var result = values.Select(x => new ResultNewsletterDto
            {
                Email = x.Email,
                NewsletterId=x.NewsletterId,
            }).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateNewsletter(CreateNewsletterDto createNewsletterDto)
        {
            _service.TInsert(new Newsletter
            {
                Email=createNewsletterDto.Email,
            });
            return Ok("Mail bültenine abone eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteNewsletter(int id)
        {
            _service.TDelete(id);
            return Ok("Mail bülteninden abone silindi");
        }
        [HttpPut]
        public IActionResult UpdateNewsletter(UpdateNewsletterDto updateNewsletterDto)
        {
            var value = _service.TGetById(updateNewsletterDto.NewsletterId);
            value.NewsletterId = updateNewsletterDto.NewsletterId;
            value.Email= updateNewsletterDto.Email;
            _service.TUpdate(value);
            return Ok("Mail bülteninde ki abone güncellendi.");
        }
        [HttpGet("GetNewsletter")]
        public IActionResult GetNewsletter(int id)
        {
            var value = _service.TGetById(id);
            var result = new ResultNewsletterDto()
            {
                Email = value.Email,
                NewsletterId = value.NewsletterId,
            };
            return Ok(result);
        }
    }
}
