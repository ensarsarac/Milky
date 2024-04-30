namespace Milky.WebUI.Areas.Admin.Dtos.AboutBannerDtos
{
    public class UpdateAboutBanner
    {
        public int AboutBannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
