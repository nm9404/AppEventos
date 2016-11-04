using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core.Model
{
    public class Venue : Place
    {
        public String Address { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String Neighborhood { get; set; }
    }
}
