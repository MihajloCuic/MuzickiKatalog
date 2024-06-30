using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public abstract class ElementSistema
    {
        private string ime;
        private int prosecnaOcena;
        private string opis;
        private int id;
        private List<Zanr> sviZanrovi;
        private List<Recenzija> sveRecenzije;

        public string Ime { get; set; }
        public int ProsecnaOcena { get; set; }
        public string Opis { get; set; }
        public int Id { get; set; }
        public List<Zanr> SviZanrovi { get; set; }
        public List<Recenzija> SveRecenzije { get; set; }
        //base konstruktor
        public ElementSistema() 
        {
            SviZanrovi = new List<Zanr>();
            sveRecenzije = new List<Recenzija>();
        }
        //parametarski konstruktor
        public ElementSistema(string _ime, int _prosecnaOcena, string _opis, int _id)
        {
            Ime = _ime;
            ProsecnaOcena = _prosecnaOcena;
            Opis = _opis;
            Id = _id;
            SviZanrovi = new List<Zanr>();
            SveRecenzije = new List<Recenzija>();
        }
        //parametarski konstruktor sa inicijalizovanim listama
        public ElementSistema(string _ime, int _prosecnaOcena, string _opis, int _id, List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije)
        { 
            Ime = _ime;
            ProsecnaOcena = _prosecnaOcena;
            Opis = _opis;
            Id = _id;
            SviZanrovi = _sviZanrovi;
            SveRecenzije = _sveRecenzije;
        }
    }
}
