using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core.Model
{
    public class Work
    {
        public String Title { get; set; }
        public String Abstract { get; set; }
        public int Year { get; set; }
        public Image Picture { get; set; }
        public int WorkId { get; set; }
        public String ShortDescription { get; set; }
    }
}
