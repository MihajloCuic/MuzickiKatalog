using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Album : ElementSistema
    {
        private DateTime datumIzdavanja;
        private List<MuzickaNumera> numereAlbuma;
        private List<ElementSistema> izvodjaci;

        public DateTime DatumIzdavanja { get; set; }
        public List<MuzickaNumera> NumereAlbuma { get; set; }
        public List<ElementSistema> Izvodjaci { get; set; }

        //base konstruktor
        public Album() 
            :base()
        {
            NumereAlbuma = new List<MuzickaNumera>();
            Izvodjaci = new List<ElementSistema>();
        }
        //parametarski konstruktor
        public Album(string _ime, int _prosecnaOcena, string _opis, int _id, DateTime _datumIzdavanja)
            : base(_ime, _prosecnaOcena, _opis, _id)
        { 
            DatumIzdavanja = _datumIzdavanja;
            NumereAlbuma = new List<MuzickaNumera>();
            Izvodjaci = new List<ElementSistema>();
        }
        //parametarski konstruktor sa inicijalizovanim listama
        public Album(string _ime, int _prosecnaOcena, string _opis, int _id, DateTime _datumIzdavanja, 
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<MuzickaNumera> _numereAlbuma, List<ElementSistema> _izvodjaci)
            : base(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije)
        {
            DatumIzdavanja = _datumIzdavanja;
            NumereAlbuma = _numereAlbuma;
            Izvodjaci = _izvodjaci;
        }
    }
}
