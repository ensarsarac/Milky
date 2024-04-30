using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete
{
    public class AboutBannerManager : IAboutBannerService
    {
        private readonly IAboutBannerDal _aboutBannerDal;

        public AboutBannerManager(IAboutBannerDal aboutBannerDal)
        {
            _aboutBannerDal = aboutBannerDal;
        }

        public void TDelete(int id)
        {
            _aboutBannerDal.Delete(id);
        }

        public AboutBanner TGetById(int id)
        {
            return _aboutBannerDal.GetById(id);
        }

        public List<AboutBanner> TGetList()
        {
            return _aboutBannerDal.GetList();
        }

        public void TInsert(AboutBanner entity)
        {
            _aboutBannerDal.Insert(entity);
        }

        public void TUpdate(AboutBanner entity)
        {
            _aboutBannerDal.Update(entity);
        }
    }
}
