using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DtoLayer.WhyUsDtos
{
    public class UpdateWhyUsDto
    {
        public int WhyUsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Article1 { get; set; }
        public string Article2 { get; set; }
        public string Article3 { get; set; }
    }
}
