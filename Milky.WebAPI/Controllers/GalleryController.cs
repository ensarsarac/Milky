using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.GalleryDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        [HttpGet]
        public IActionResult GalleryList()
        {
            var values = _galleryService.TGetList();
            var result = values.Select(x => new ResultGalleryDto
            {
                GalleryId = x.GalleryId,
                ImageUrl=x.ImageUrl,
            }).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateGallery(CreateGalleryDto createGalleryDto)
        {
            _galleryService.TInsert(new Gallery
            {
                ImageUrl = createGalleryDto.ImageUrl,
            });
            return Ok("Resim eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteGallery(int id)
        {
            _galleryService.TDelete(id);
            return Ok("Resim silindi");
        }
        [HttpPut]
        public IActionResult UpdateGallery(UpdateGalleryDto updateGalleryDto)
        {
            var value = _galleryService.TGetById(updateGalleryDto.GalleryId);
            value.ImageUrl = updateGalleryDto.ImageUrl;
            _galleryService.TUpdate(value);
            return Ok("Resim güncellendi.");
        }
        [HttpGet("GetGallery")]
        public IActionResult GetGallery(int id)
        {
            var value = _galleryService.TGetById(id);
            var result = new ResultGalleryDto()
            {
                ImageUrl=value.ImageUrl,
                GalleryId=value.GalleryId,
            };
            return Ok(result);
        }


    }
}
