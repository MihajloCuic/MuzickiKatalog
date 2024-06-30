using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class MuzickaNumera : ElementSistema
    {
        private DateTime datumIzbacivanja;
        private List<ElementSistema> izvodjaci;

        public DateTime DatumIzbacivanja { get; set; }
        public List<ElementSistema> Izvodjaci { get; set; }
        //base konstruktor
        public MuzickaNumera()
            :base()
        { 
            Izvodjaci = new List<ElementSistema>();
        }
        //parametarski konstruktor
        public MuzickaNumera(string _ime, int _prosecnaOcena, string _opis, int _id, DateTime _datumIzbacivanja)
            :base(_ime, _prosecnaOcena, _opis, _id)
        { 
            DatumIzbacivanja = _datumIzbacivanja;
            Izvodjaci = new List<ElementSistema>();
        }
        //parametarski konstruktor sa inicijalizovanim listama
        public MuzickaNumera(string _ime, int _prosecnaOcena, string _opis, int _id, DateTime _datumIzbacivanja,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<ElementSistema> _izvodjaci)
            : base(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije)
        {
            DatumIzbacivanja = _datumIzbacivanja;
            Izvodjaci = _izvodjaci;
        }
    }
}
