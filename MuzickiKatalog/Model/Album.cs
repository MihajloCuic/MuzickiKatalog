using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Album : ElementSistema
    {
        private DateTime datumIzdavanja;
        private List<MuzickaNumera> numereAlbuma;
        private List<ElementSistema> izvodjaci;

        public DateTime DatumIzdavanja { get; set; }
        public List<MuzickaNumera> NumereAlbuma { get; set; }
        public List<ElementSistema> Izvodjaci { get; set; }
    }
}
