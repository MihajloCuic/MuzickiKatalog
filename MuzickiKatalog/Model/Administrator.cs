using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Administrator : Osoba
    {
        private static readonly string fajl = Path.Combine("..", "..", "..", "Data", "Administratori.json");
        //base konstruktor
        public Administrator()
            : base()
        { }
        //parametarski konstruktor
        public Administrator(string _ime, string _prezime, string _email, string _telefon, string _id)
            : base(_ime, _prezime, _email, _telefon, _id) { }
        //parametarski konstruktor sa inicijalizovanom listom
        public Administrator(string _ime, string _prezime, string _email, string _telefon, string _id, List<Recenzija> _sveRecenzije)
            : base(_ime, _prezime, _email, _telefon, _id, _sveRecenzije) { }
        //citanje administratora iz fajla
        public static Dictionary<string, Administrator> UcitajAdministratore()
        {
            Dictionary<string, Administrator> sviAdministratori = new Dictionary<string, Administrator>();
            try
            {
                string data = File.ReadAllText(fajl);
                sviAdministratori = JsonConvert.DeserializeObject<Dictionary<string, Administrator>>(data);
            }
            catch (IOException ex)
            {
                throw new Exception("Greska pri citanju fajla!");
            }
            return sviAdministratori;
        }
        //pisanje administratora u fajl
        public static void UpisiAdministratore(Dictionary<string, Administrator> sviAdministratori)
        {
            try
            {
                string data = JsonConvert.SerializeObject(sviAdministratori, Formatting.Indented);
                File.WriteAllText(fajl, data);
            }
            catch (IOException ex)
            {
                throw new Exception("Greska pri upisu u fajl!");
            }
        }
        //Dodaj administratora
        public void Dodaj()
        {
            Dictionary<string, Administrator> sviAdministratori = UcitajAdministratore();
            if (sviAdministratori.ContainsKey(Id))
            {
                throw new Exception("Administrator vec postoji!");
            }

            sviAdministratori[Id] = this;
            UpisiAdministratore(sviAdministratori);
        }
        //Izmeni administratora
        public void Izmeni(string ime, string prezime, string telefon,
            List<Recenzija> sveRecenzije)
        {
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            SveRecenzije = sveRecenzije;

            Dictionary<string, Administrator> sviAdministratori = UcitajAdministratore();
            if (!sviAdministratori.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeni administrator!");
            }
            sviAdministratori[Id] = this;
            UpisiAdministratore(sviAdministratori);
        }
        //Obrisi administratora
        public void Obrisi()
        {
            Dictionary<string, Administrator> sviAdministratori = UcitajAdministratore();
            if (!sviAdministratori.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeni administrator!");
            }
            sviAdministratori.Remove(Id);
            UpisiAdministratore(sviAdministratori);
        }
        //dodavanje elementa sistema
        //public ElementSistema DodavanjeElementaSistema() { }
        //dodavanje muzickog urednika
        //public MuzickiUrednik DodavanjeMuzickogUrednika() { }
        //prikaz svih muzickih urednika
        //public List<MuzickiUrednik> prikazMuzickihUrednika() { }
        //izmena elementa sistema
        public void IzmenaElementaSistema(ElementSistema elementSistema) { }
        //izmena muzickog urednika
        public void IzmenaMuzickogUrednika(MuzickiUrednik muzickiUrednik) { }
        //dodeljivanje recenzije
        public void DodeliRecenziju(Recenzija recenzija, MuzickiUrednik muzickiUrednik) { }
        //postavljanje reklame
        public void PostaviReklamu() { }
        //dodavanje glasanja
        //public Glasanje dodajGlasanje() { }
        //uredjivanje pocetne stranice
        public void UredjivanjePocetneStranice() { }
        //blokiranje korisnika
        public void BlokiranjeKorisnika(Korisnik korisnik) { }
        //brisanje neprikladne recenzije korisnika
        public void BrisanjeKorisnickeRecenzije() { }
        //davanje dozvole za izmenu recenzije
        public void DozvolaIzmenaRecenzije(Recenzija recenzija, Korisnik korisnik) { }
        //dodavanje novog zanra
        public void DodavanjeNovogZanra(Zanr noviZanr) { }
    }
}
