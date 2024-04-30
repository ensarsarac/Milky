using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.EntityLayer.Concrete
{
    public class About
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Services1 { get; set; }
        public string Services1Icon { get; set; }
        public string Services1Description { get; set; }
        public string Services2{ get; set; }
        public string Services2Description { get; set; }
        public string Services2Icon { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
    }
}
