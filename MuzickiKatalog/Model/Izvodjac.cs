using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Izvodjac : ElementSistema
    {
        private List<MuzickaNumera> numere;
        private MuzickaGrupa grupa;

        public List<MuzickaNumera> Numere { get; set; }
        public MuzickaGrupa Grupa { get; set; }
        //base konstruktor
        public Izvodjac() 
            :base()
        {
            Grupa = null;
            Numere = new List<MuzickaNumera>();
        }
        //parametarski konstruktor
        public Izvodjac(string _ime, int _prosecnaOcena, string _opis, int _id, MuzickaGrupa _muzickaGrupa)
            : base(_ime, _prosecnaOcena, _opis, _id)
        {
            Grupa = _muzickaGrupa;
            Numere = new List<MuzickaNumera>();
        }
        //parametarski konstruktor sa inicijalizovanom listom
        public Izvodjac(string _ime, int _prosecnaOcena, string _opis, int _id, MuzickaGrupa _muzickaGrupa,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<MuzickaNumera> _numere)
            : base(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije)
        { 
            Grupa = _muzickaGrupa;
            Numere = _numere;
        }
    }
}
