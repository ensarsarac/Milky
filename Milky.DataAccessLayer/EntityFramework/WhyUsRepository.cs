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
    public class WhyUsRepository : GenericRepositories<WhyUs>, IWhyUsDal
    {
        public WhyUsRepository(MilkyContext context) : base(context)
        {

        }
    }
}
