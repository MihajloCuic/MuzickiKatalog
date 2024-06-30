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
        //base konstruktor
        public Koncert() 
            :base()
        {
            ElementiKoncerta = new List<ElementSistema>();
        }
        //parametarski konstruktor
        public Koncert(string _ime, int _prosecnaOcena, string _opis, int _id, string _snimatelj, string _formatPrikaza, DateTime _datumDesavanja)
            : base(_ime, _prosecnaOcena, _opis, _id)
        { 
            Snimatelj = _snimatelj;
            FormatPrikaza = _formatPrikaza;
            DatumDesavanja = _datumDesavanja;
            ElementiKoncerta = new List<ElementSistema>();
        }
        //parametarski konstruktor sa inicijalizovanim listama
        public Koncert(string _ime, int _prosecnaOcena, string _opis, int _id, string _snimatelj, string _formatPrikaza, DateTime _datumDesavanja,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<ElementSistema> _elementiKoncerta)
            : base(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije)
        {
            Snimatelj = _snimatelj;
            FormatPrikaza = _formatPrikaza;
            DatumDesavanja = _datumDesavanja;
            ElementiKoncerta = _elementiKoncerta;
        }
    }
}
