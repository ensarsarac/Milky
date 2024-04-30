using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.ContactInfoDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }
        [HttpGet]
        public IActionResult ContactInfoList()
        {
            var values = _contactInfoService.TGetList();
            var result = values.Select(x => new ResultContactInfoDto
            {
                Address = x.Address,
                ContactInfoId = x.ContactInfoId,
                Email = x.Email,
                Phone = x.Phone
            }).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateContactInfo(CreateContactInfoDto createContactInfoDto)
        {
            _contactInfoService.TInsert(new ContactInfo
            {
                Phone = createContactInfoDto.Phone,
                Email = createContactInfoDto.Email,
                Address = createContactInfoDto.Address,
            });
            return Ok("İletişim bilgileri eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteContactInfo(int id)
        {
            _contactInfoService.TDelete(id);
            return Ok("İletişim bilgileri silindi");
        }
        [HttpPut]
        public IActionResult UpdateContactInfo(UpdateContactInfoDto updateContactInfoDto)
        {
            var value = _contactInfoService.TGetById(updateContactInfoDto.ContactInfoId);
            value.Phone = updateContactInfoDto.Phone;
            value.Address= updateContactInfoDto.Address;
            value.Email = updateContactInfoDto.Email;
            _contactInfoService.TUpdate(value);
            return Ok("İletişim bilgileri güncellendi.");
        }
        [HttpGet("GetContactInfo")]
        public IActionResult GetContactInfo(int id)
        {
            var value = _contactInfoService.TGetById(id);
            var result = new ResultContactInfoDto()
            {
                Address = value.Address,
                ContactInfoId = value.ContactInfoId,
                Email = value.Email,
                Phone = value.Phone
            };
            return Ok(result);
        }


    }
}
