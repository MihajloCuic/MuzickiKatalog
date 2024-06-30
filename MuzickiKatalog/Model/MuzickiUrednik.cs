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
        //base konstruktor
        public MuzickiUrednik() 
        {
            SviZanrovi = new List<Zanr>();
        }
        //parametarski konstruktor
        public MuzickiUrednik(string _ime, string _prezime, string _email, string _telefon, string _id)
            : base(_ime, _prezime, _email, _telefon, _id)
        {
            SviZanrovi = new List<Zanr>();
        }
        //parametarski konstruktor sa inicijalizovanom listom
        public MuzickiUrednik(string _ime, string _prezime, string _email, string _telefon, string _id, List<Recenzija> _sveRecenzije, List<Zanr> _sviZanrovi)
            : base(_ime, _prezime, _email, _telefon, _id, _sveRecenzije)
        {
            SviZanrovi = _sviZanrovi;
        }
    }
}
