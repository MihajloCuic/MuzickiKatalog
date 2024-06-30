using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Korisnik : Osoba
    {
        private List<Playlista> svePlayliste;
        private List<ElementSistema> omiljeno;
        public List<Playlista> SvePlayliste { get; set; }
        public List<ElementSistema> Omiljeno { get; set; }
        
    }
}
