using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Koncert : ElementSistema
    {
        private string snimatelj;
        private string formatPrikaza;
        private DateTime datumDesavanja;
        private List<ElementSistema> elementiKoncerta;

        public string Snimatelj { get; set; }
        public string FormatPrikaza { get; set; }
        public DateTime DatumDesavanja { get; set; }
        public List<ElementSistema> ElementiKoncerta { get; set; }
    }
}
