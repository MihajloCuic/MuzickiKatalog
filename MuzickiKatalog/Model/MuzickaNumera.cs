using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class MuzickaNumera : ElementSistema
    {
        private DateTime datumIzbacivanja;
        private List<ElementSistema> izvodjaci;

        public DateTime DatumIzbacivanja { get; set; }
        public List<ElementSistema> Izvodjaci { get; set; }
    }
}
