using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Korisnik : Osoba
    {
        private List<Playlista> svePlayliste;
        private List<ElementSistema> omiljeno;
        public List<Playlista> SvePlayliste { get; set; }
        public List<ElementSistema> Omiljeno { get; set; }

        //base konstruktor
        public Korisnik()
        {
            SvePlayliste = new List<Playlista>();
            Omiljeno = new List<ElementSistema>();
        }
        //parametarski konstruktor
        public Korisnik(string _ime, string _prezime, string _email, string _telefon, string _id)
            : base(_ime, _prezime, _email, _telefon, _id)
        {
            SvePlayliste = new List<Playlista>();
            Omiljeno = new List<ElementSistema>();
        }
        //parametarski konstruktor sa inicijalizovanom listom
        public Korisnik(string _ime, string _prezime, string _email, string _telefon, string _id,
            List<Recenzija> _sveRecenzije, List<Playlista> _svePlayliste, List<ElementSistema> _omiljeno)
            : base(_ime, _prezime, _email, _telefon, _id, _sveRecenzije)
        {
            SvePlayliste = _svePlayliste;
            Omiljeno = _omiljeno;
        }
    }
}
