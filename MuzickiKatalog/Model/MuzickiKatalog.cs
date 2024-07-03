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
        //izmena playlisti sistema (playlista godine, meseca)
        public void IzmeniPlaylistu(int idPlayliste, List<MuzickaNumera> numere)
        {
            foreach (Playlista playlista in svePlayliste)
            {
                if (idPlayliste != playlista.Id)
                {
                    continue;
                }
                foreach (var numera in playlista.Numere)
                {
                    playlista.UkloniNumeru(numera.Value);
                }
                foreach (MuzickaNumera numera in numere)
                { 
                    playlista.DodajNumeru(numera);
                }
            }
        }
    }
}
