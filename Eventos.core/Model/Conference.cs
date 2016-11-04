using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core.Model
{
    public class Conference : Work
    {
        public Place ConferencePlace { get; set; }
        public Time Hour { get; set; }
        public DateF Date { get; set; }
        public int ConferenceId { get; set; }
    }
}
