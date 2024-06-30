using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Glasanje
    {
        private int id;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private string imeTakmicenja;
        private List<ElementSistema> kandidati;
        private List<Glas> glasovi;

        public int Id { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public string ImeTakmicenja { get; set; }
        public List<ElementSistema> Kandidati { get; set; }
        public List<Glas> Glasovi { get; set; }
    }
}
