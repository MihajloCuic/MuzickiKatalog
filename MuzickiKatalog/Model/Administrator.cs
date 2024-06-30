using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Administrator : Osoba
    {
        //base konstruktor
        public Administrator() { }
        //parametarski konstruktor
        public Administrator(string _ime, string _prezime, string _email, string _telefon, string _id)
            : base(_ime, _prezime, _email, _telefon, _id) { }
        //parametarski konstruktor sa inicijalizovanom listom
        public Administrator(string _ime, string _prezime, string _email, string _telefon, string _id, List<Recenzija> _sveRecenzije)
            : base(_ime, _prezime, _email, _telefon, _id, _sveRecenzije) { }
    }
}
