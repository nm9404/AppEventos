using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core.Model
{
    public class Place
    {
        //public float[] Location { get; set; } Deprecated
        public int Capacity { get; set; }
        public Coordinate Location { get; set; }
        public string Name { get; set; }
        public Image Picture { get; set; }
        public int PlaceId { get; set; }
    }
}
