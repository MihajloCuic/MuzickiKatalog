using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class MuzickaGrupa : ElementSistema
    {
        private List<Izvodjac> izvodjaci;
        private List<MuzickaNumera> numere;

        public List<Izvodjac> Izvodjaci { get; set; }
        public List<MuzickaNumera> Numere { get; set; }
        //base konstruktor
        public MuzickaGrupa()
            :base() 
        {
            Izvodjaci = new List<Izvodjac>();
            Numere = new List<MuzickaNumera>();
        }
        //parametarski konstruktor
        public MuzickaGrupa(string _ime, int _prosecnaOcena, string _opis, int _id)
            : base(_ime, _prosecnaOcena, _opis, _id)
        {
            Izvodjaci = new List<Izvodjac>();
            Numere = new List<MuzickaNumera>();
        }
        //parametarski konstruktor sa inicijalizovanom listom
        public MuzickaGrupa(string _ime, int _prosecnaOcena, string _opis, int _id,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<Izvodjac> _izvodjaci, List<MuzickaNumera> _numere)
            : base(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije)
        { 
            Izvodjaci = _izvodjaci;
            Numere = _numere;
        }
    }
}
