﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DtoLayer.SocialMediaDtos
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string Platform { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
    }
}
