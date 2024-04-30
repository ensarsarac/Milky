using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.MessageDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetList();
            var result = values.Select(x => new ResultMessageDto
            {
                Content= x.Content,
                Date = x.Date,
                Email = x.Email,
                MessageId = x.MessageId,
                NameSurname = x.NameSurname,
                Subject = x.Subject
            }).ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            _messageService.TInsert(new Message
            {
                Subject = createMessageDto.Subject,
                NameSurname=createMessageDto.NameSurname,
                Email = createMessageDto.Email,
                Date = createMessageDto.Date,
                Content = createMessageDto.Content,
            });
            return Ok("Mesaj eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return Ok("Mesaj silindi");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _messageService.TGetById(updateMessageDto.MessageId);
            value.NameSurname = updateMessageDto.NameSurname;
            value.Email = updateMessageDto.Email;
            value.Date = updateMessageDto.Date;
            value.Content = updateMessageDto.Content;
            value.Subject = updateMessageDto.Subject;
            value.MessageId = updateMessageDto.MessageId;
            _messageService.TUpdate(value);
            return Ok("Mesaj güncellendi.");
        }
        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetById(id);
            var result = new ResultMessageDto()
            {
                Content = value.Content,
                Date = value.Date,
                Email = value.Email,
                MessageId = value.MessageId,
                NameSurname = value.NameSurname,
                Subject = value.Subject
            };
            return Ok(result);
        }
    }
}
