using Microsoft.Extensions.DependencyInjection;
using Milky.BusinessLayer.Abstract;
using Milky.BusinessLayer.Concrete;
using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Container
{
	public static class Extension
	{
		public static void AddDepencies(this IServiceCollection services)
		{
			services.AddScoped<ICategoryDal, CategoryRepository>();
			services.AddScoped<ICategoryService, CategoryManager>();
			services.AddScoped<ISliderDal, SliderRepository>();
			services.AddScoped<ISliderService, SliderManager>();
			services.AddScoped<IProductDal, ProductRepository>();
			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<IAboutDal, AboutRepository>();
			services.AddScoped<IAboutService,AboutManager>();
			services.AddScoped<IAboutBannerService,AboutBannerManager>();
			services.AddScoped<IAboutBannerDal,AboutBannerRepository>();
			services.AddScoped<IContactInfoService,ContactInfoManager>();
			services.AddScoped<IContactInfoDal,ContactInfoRepository>();
			services.AddScoped<IGalleryDal,GalleryRepository>();
			services.AddScoped<IGalleryService,GalleryManager>();
			services.AddScoped<IServiceService,ServiceManager>();
			services.AddScoped<IServiceDal,ServiceRepository>();
			services.AddScoped<ISocialMediaDal,SocialMediaRepository>();
			services.AddScoped<ISocialMediaService,SocialMediaManager>();
			services.AddScoped<ITeamDal,TeamRepository>();
			services.AddScoped<ITeamService,TeamManager>();
			services.AddScoped<ITestimonialDal,TestimonialRepository>();
			services.AddScoped<ITestimonialService,TestimonialManager>();
			services.AddScoped<IWhyUsDal,WhyUsRepository>();
			services.AddScoped<IWhyUsService,WhyUsManager>();
			services.AddScoped<IOpenHourDal,OpenHourRepository>();
			services.AddScoped<IOpenHourService,OpenHourManager>();
			services.AddScoped<INewsletterDal,NewsletterRepository>();
			services.AddScoped<INewsletterService,NewsletterManager>();
			services.AddScoped<ITeamSocialMediaDal,TeamSocialMediaRepository>();
			services.AddScoped<ITeamSocialMediaService,TeamSocialMediaManager>();
			services.AddScoped<IMessageDal,MessageRepository>();
			services.AddScoped<IMessageService,MessageManager>();

		}
	}
}
