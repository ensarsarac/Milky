using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Milky.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DataAccessLayer.Concrete
{
	public class MilkyContext:IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-JI387RJ\\SQLEXPRESS;initial catalog=MilkyDb;integrated security=true");
		}
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Slider> Sliders{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<About> Abouts{ get; set; }
        public DbSet<AboutBanner> AboutBanners{ get; set; }
        public DbSet<Gallery> Galleries{ get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<Team> Teams{ get; set; }
        public DbSet<Testimonial> Testimonials{ get; set; }
        public DbSet<WhyUs> WhyUss{ get; set; }
        public DbSet<SocialMedia> SocialMedias{ get; set; }
        public DbSet<ContactInfo> ContactInfos{ get; set; }
        public DbSet<OpenHour> OpenHours{ get; set; }
        public DbSet<Newsletter> Newsletters{ get; set; }
        public DbSet<TeamSocialMedia> TeamSocialMedias{ get; set; }
        public DbSet<Message> Messages{ get; set; }
    }
}
