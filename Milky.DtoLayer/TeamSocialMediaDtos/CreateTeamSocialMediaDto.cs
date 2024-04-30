﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DtoLayer.TeamSocialMediaDtos
{
    public class CreateTeamSocialMediaDto
    {
        public string Url { get; set; }
        public string Platform { get; set; }
        public string Icon { get; set; }
        public int TeamId { get; set; }
    }
}
