using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Genre:BusinessObject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
