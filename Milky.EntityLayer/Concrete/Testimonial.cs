﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.EntityLayer.Concrete
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string ClientName { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
