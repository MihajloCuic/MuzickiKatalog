using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    class MuzickiUrednik : Osoba
    {
        private List<Zanr> sviZanrovi;

        public List<Zanr> SviZanrovi { get; set; }
    }
}
