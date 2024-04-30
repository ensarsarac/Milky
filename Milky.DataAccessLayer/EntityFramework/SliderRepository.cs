﻿using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.Concrete;
using Milky.DataAccessLayer.Repositories;
using Milky.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DataAccessLayer.EntityFramework
{
	public class SliderRepository : GenericRepositories<Slider>, ISliderDal
	{
		public SliderRepository(MilkyContext context) : base(context)
		{

		}
	}
}
