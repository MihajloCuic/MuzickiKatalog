using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Izvodjac : ElementSistema
    {
        private List<MuzickaNumera> numere;
        private MuzickaGrupa grupa;

        public List<MuzickaNumera> Numere { get; set; }
        public MuzickaGrupa Grupa { get; set; }
    }
}
