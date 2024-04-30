namespace Milky.WebUI.Areas.Admin.Dtos.TeamSocialMediaDtos
{
    public class CreateTeamSocialMediaDto
    {
        public string Url { get; set; }
        public string Platform { get; set; }
        public string Icon { get; set; }
        public int TeamId { get; set; }
    }
}
