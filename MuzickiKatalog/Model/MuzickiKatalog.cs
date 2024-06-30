using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    class MuzickiKatalog
    {
        private string naziv;
        private List<Playlista> svePlayliste;
        public string Naziv { get; set; }
        public List<Playlista> SvePlayliste { get; set; }
    }
}
