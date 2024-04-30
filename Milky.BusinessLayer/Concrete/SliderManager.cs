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
	public class SliderManager : ISliderService
	{
		private readonly ISliderDal _sliderDal;

		public SliderManager(ISliderDal sliderDal)
		{
			_sliderDal = sliderDal;
		}

		public void TDelete(int id)
		{
			_sliderDal.Delete(id);
		}

		public Slider TGetById(int id)
		{
			return _sliderDal.GetById(id);	
		}

		public List<Slider> TGetList()
		{
			return _sliderDal.GetList();
		}

		public void TInsert(Slider entity)
		{
			_sliderDal.Insert(entity);
		}

		public void TUpdate(Slider entity)
		{
			_sliderDal.Update(entity);
		}
	}
}
