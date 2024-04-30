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
    public class ContactInfoManager : IContactInfoService
    {
        private readonly IContactInfoDal _contactInfoDal;

        public ContactInfoManager(IContactInfoDal contactInfoDal)
        {
            _contactInfoDal = contactInfoDal;
        }

        public void TDelete(int id)
        {
            _contactInfoDal.Delete(id);
        }

        public ContactInfo TGetById(int id)
        {
            return _contactInfoDal.GetById(id);
        }

        public List<ContactInfo> TGetList()
        {
            return _contactInfoDal.GetList();
        }

        public void TInsert(ContactInfo entity)
        {
            _contactInfoDal.Insert(entity);
        }

        public void TUpdate(ContactInfo entity)
        {
            _contactInfoDal.Update(entity);
        }
    }
}
