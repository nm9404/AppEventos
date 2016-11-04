using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core.Model
{
    public class MainEvent
    {
        public Venue Place { get; set; }
        public GeneralInformation EventInformation { get; set; }
        public List<Presenter> Presenters { get; set; }
        public List<FrequentQuestion> FrequentQuestions { get; set; }
        public List<Image> ImageGallery { get; set; }
        public int EventId { get; set; }
    }
}
