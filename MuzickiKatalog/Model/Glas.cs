using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Glas
    {
        private Osoba glasac;
        private ElementSistema izglasaniElement;

        public Osoba Glasac { get; set; }
        public ElementSistema IzglasaniElement { get; set; }
    }
}
