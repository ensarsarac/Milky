namespace Milky.WebUI.Areas.Admin.Dtos.ContactInfoDtos
{
    public class UpdateContactInfoDto
    {
        public int ContactInfoId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
