using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Newtonsoft.Json;

namespace MuzickiKatalog.Model
{
    public class MuzickiUrednik : Osoba
    {
        private static readonly string fajl = Path.Combine("..", "..", "..", "Data", "MuzickiUrednici.json");
        private List<Zanr> sviZanrovi;
        public List<Zanr> SviZanrovi { get; set; }
        //base konstruktor
        public MuzickiUrednik() 
            :base()
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
        //citanje muzickih urednika iz fajla
        public static Dictionary<string, MuzickiUrednik> UcitajUrednike()
        {
            Dictionary<string, MuzickiUrednik> sviUrednici = new Dictionary<string, MuzickiUrednik>();
            try
            {
                string data = File.ReadAllText(fajl);
                sviUrednici = JsonConvert.DeserializeObject<Dictionary<string, MuzickiUrednik>>(data);
            }
            catch (IOException ex)
            {
                throw new Exception("Greska u citanju fajla!");
            }
            return sviUrednici;
        }
        //pisanje muzickih urednika u fajl
        public static void UpisiUrednike(Dictionary<string, MuzickiUrednik> sviUrednici) 
        {
            try
            {
                string data = JsonConvert.SerializeObject(sviUrednici, Formatting.Indented);
                File.WriteAllText(fajl, data);
            }
            catch (IOException ex)
            {
                throw new Exception("Greska u pisanju u fajl!");
            }
        }
        //Dodaj muzickog urednika
        public void Dodaj() 
        { 
            Dictionary<string, MuzickiUrednik> sviUrednici = UcitajUrednike();
            if (sviUrednici.ContainsKey(Id))
            {
                throw new Exception("Urednik vec postoji!");
            }

            sviUrednici[Id] = this;
            UpisiUrednike(sviUrednici);
        }
        //Izmeni muzickog urednika
        public void Izmeni(string ime, string prezime, string telefon,
            List<Recenzija> sveRecenzije, List<Zanr> sviZanrovi) 
        {
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            SveRecenzije = sveRecenzije;
            SviZanrovi = sviZanrovi;

            Dictionary<string, MuzickiUrednik> sviUrednici = UcitajUrednike();
            if (!sviUrednici.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeni urednik!");
            }
            sviUrednici[Id] = this;
            UpisiUrednike(sviUrednici);
        }
        //Obrisi muzickog urednika
        public void Obrisi() 
        {
            Dictionary<string, MuzickiUrednik> sviUrednici = UcitajUrednike();
            if (!sviUrednici.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeni urednik!");
            }
            sviUrednici.Remove(Id);
            UpisiUrednike(sviUrednici);
        }
        //Prikaz dodeljenih recenzija
        public List<Recenzija> PrikaziDodeljeneRecenzije() 
        {
            List<Recenzija> dodeljeneRecenzije = new List<Recenzija>();
            //TODO dodati logiku za prikaz dodeljenih recenzija
            return dodeljeneRecenzije;
        }
        //Dodavanje novog elementa
        public void DodajElementSistema(
            string _ime,
            int _prosecnaOcena,
            string _opis,
            int _id,
            List<Zanr> _sviZanrovi,
            List<Recenzija> _sveRecenzije,

            DateTime? _datum = null,

            List<ElementSistema> _izvodjaciKoncert = null,

            List<MuzickaNumera> _muzickeNumere = null,

            string _snimatelj = null,
            string _formatPrikaza = null,

            List<Izvodjac> _izvodjaci = null,

            MuzickaGrupa _grupa = null

            ///numera
            //DateTime? datumIzbacivanja = null,
            //List<Izvodjac> izvodjaci = null,

            //koncert
            //DateTime? datumDesavanja = null,
            //string snimatelj = null,
            //string formatPrikaza = null,
            //List<ElementSistema> elementiKoncerta = null,

            //album
            //DateTime? datumIzdavanja = null,
            //List<MuzickaNumera> numereAlbuma = null,
            //List<Izvodjac> izvodjaciAlbum = null


            ///grupa
            //List<Izvodjac> izvodjaciGrupa = null,
            //List<MuzickaNumera> numereGrupa = null,

            //izvodjac
            //List<MuzickaNumera> numereIzvodjac = null,
            //MuzickaGrupa grupaIzvodjac = null
            )
        {
            int m = 0;
            if (_datum == null)
            {
                if (_izvodjaci != null)
                {
                    if (_izvodjaci[0] != null)
                    {
                        //grupa
                        MuzickaGrupa muzickaGrupa = new MuzickaGrupa(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije, _izvodjaci, _muzickeNumere);
                        muzickaGrupa.Dodaj();
                    }
                    
                }
                else if(_grupa!=null)
                {
                    //izvodjac
                    Izvodjac izvodjac = new Izvodjac(_ime, _prosecnaOcena, _opis, _id, _grupa, _sviZanrovi, _sveRecenzije, _muzickeNumere);
                    izvodjac.Dodaj();
                }

            }
            else
            {

                if (_snimatelj != null && _snimatelj!="")
                {
                    //koncert
                    Koncert koncert = new Koncert(_ime, _prosecnaOcena, _opis, _id, _snimatelj, _formatPrikaza, _datum.GetValueOrDefault(), _sviZanrovi, _sveRecenzije, _izvodjaciKoncert);
                    koncert.Dodaj();
                }
                else if (_muzickeNumere != null)
                {
                    if (_muzickeNumere[0]!=null)
                    {
                        //album
                        Album album = new Album(_ime, _prosecnaOcena, _opis, _id, _datum.GetValueOrDefault(), _sviZanrovi, _sveRecenzije, _muzickeNumere, _izvodjaci);
                        album.Dodaj();
                        return;
                    }
                    //numera
                    MuzickaNumera muzickaNumera = new MuzickaNumera(_ime, _prosecnaOcena, _opis, _id, _datum.GetValueOrDefault(), _sviZanrovi, _sveRecenzije, _izvodjaci);
                    muzickaNumera.Dodaj();
                }
                else
                {
                    //numera
                    MuzickaNumera muzickaNumera = new MuzickaNumera(_ime, _prosecnaOcena, _opis, _id, _datum.GetValueOrDefault(), _sviZanrovi, _sveRecenzije, _izvodjaci);
                    muzickaNumera.Dodaj();
                }
            }
        }
        //Dodavanje nove recenzije
        public void OstaviRecenziju(Recenzija novaRecenzija) 
        {
            Dictionary<string, MuzickiUrednik> sviUrednici = UcitajUrednike();
            sviUrednici[Id].SveRecenzije.Add(novaRecenzija);
            UpisiUrednike(sviUrednici);
        }
        //brisanje neprikladne korisnicke recenzije
        public void ModerirajKorisnickuRecenziju(Korisnik korisnik) { }
        //Glasaj
        public void Glasaj() { }
    }
}
