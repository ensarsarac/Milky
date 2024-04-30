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
    public class OpenHourManager : IOpenHourService
    {
        private readonly IOpenHourDal _openHourDal;

        public OpenHourManager(IOpenHourDal openHourDal)
        {
            _openHourDal = openHourDal;
        }

        public void TDelete(int id)
        {
            _openHourDal.Delete(id);
        }

        public OpenHour TGetById(int id)
        {
            return _openHourDal.GetById(id);
        }

        public List<OpenHour> TGetList()
        {
            return _openHourDal.GetList();
        }

        public void TInsert(OpenHour entity)
        {
            _openHourDal.Insert(entity);
        }

        public void TUpdate(OpenHour entity)
        {
            _openHourDal.Update(entity);
        }
    }
}
