using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public abstract class Osoba
    {
        private string ime;
        private string prezime;
        private string email;
        private string telefon;
        private string id;
        private List<Recenzija> sveRecenzije;

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Id { get; set; }
        public List<Recenzija> SveRecenzije { get; set; }

        //base konstruktor
        public Osoba()
        {
            SveRecenzije = new List<Recenzija>();
        }
        //parametarski konstruktor
        public Osoba(string _ime, string _prezime, string _email, string _telefon, string _id)
        {
            Ime = _ime;
            Prezime = _prezime;
            Email = _email;
            Telefon = _telefon;
            Id = _id;
            SveRecenzije = new List<Recenzija>();
        }
        //parametarski konstruktor sa inicijalizovanom listom
        public Osoba(string _ime, string _prezime, string _email, string _telefon, string _id, List<Recenzija> _sveRecenzije)
        {
            Ime = _ime;
            Prezime = _prezime;
            Email = _email;
            Telefon = _telefon;
            Id = _id;
            SveRecenzije = _sveRecenzije;
        }
    }
}
