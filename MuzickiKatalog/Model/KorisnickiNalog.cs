using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickiKatalog.Helpers;

namespace MuzickiKatalog.Model
{
    class KorisnickiNalog
    {
        private string korisnickoIme;
        private string lozinka;
        private VrstaKorisnika vrstaKorisnika;

        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public VrstaKorisnika VrstaKorisnika { get; set; }
    }
}
