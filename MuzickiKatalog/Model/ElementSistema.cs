using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public abstract class ElementSistema
    {
        private string ime;
        private int prosecnaOcena;
        private string opis;
        private int id;
        private List<Zanr> sviZanrovi;
        private List<Recenzija> sveRecenzije;

        public string Ime { get; set; }
        public int ProsecnaOcena { get; set; }
        public string Opis { get; set; }
        public int Id { get; set; }
        public List<Zanr> SviZanrovi { get; set; }
        public List<Recenzija> SveRecenzije { get; set; }
    }
}
