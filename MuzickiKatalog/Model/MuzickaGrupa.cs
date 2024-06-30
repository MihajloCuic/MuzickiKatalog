using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class MuzickaGrupa : ElementSistema
    {
        private List<Izvodjac> izvodjaci;
        private List<MuzickaNumera> numere;

        public List<Izvodjac> Izvodjaci { get; set; }
        public List<MuzickaNumera> Numere { get; set; }
    }
}
