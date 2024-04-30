using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.ServiceDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _service.TGetList();
            var result = values.Select(x => new ResultServiceDto()
            {
                ImageUrl = x.ImageUrl,
                Description = x.Description,
                ServiceId = x.ServiceId,
                Title = x.Title
            }).ToList();

            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createServiceDto)
        {
            _service.TInsert(new Service
            {
                Title = createServiceDto.Title,
                ImageUrl = createServiceDto.ImageUrl,
                Description = createServiceDto.Description,
            });
            return Ok("Hizmet eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            _service.TDelete(id);
            return Ok("Hizmet silindi");
        }
        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
            var value = _service.TGetById(updateServiceDto.ServiceId);
            value.Title = updateServiceDto.Title;
            value.Description = updateServiceDto.Description;
            value.ImageUrl = updateServiceDto.ImageUrl;
            _service.TUpdate(value);
            return Ok("Hizmet güncellendi.");
        }
        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _service.TGetById(id);
            var result = new ResultServiceDto()
            {
                ImageUrl = value.ImageUrl,
                Description= value.Description,
                Title = value.Title,
                ServiceId=value.ServiceId,
            };
            return Ok(result);
        }
    }
}
