using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core.Model
{
    public class GeneralInformation
    {
        public Image MainImage { get; set; }
        public List<SocialNetwork> EventSocialNetworks { get; set; }
        public String EventDescription { get; set; }
        public String EventName { get; set; }
    }
}
