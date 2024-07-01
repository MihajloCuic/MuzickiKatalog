using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuzickiKatalog.Model
{
    class MuzickiUrednik : Osoba
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
        //public ElementSistema DodavanjeElementaSistema() {}
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
