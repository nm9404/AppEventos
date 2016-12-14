using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core.Model
{
    public class Presenter
    {
        public string Name { get; set; }
        public String Profile { get; set; }
        public String Country { get; set; }
        public Image Photo { get; set; }
        public List<Work> PreviousWorks { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public int PresenterId { get; set; }
    }
}
