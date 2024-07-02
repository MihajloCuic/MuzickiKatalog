using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using MuzickiKatalog.Helpers;

namespace MuzickiKatalog.Model
{
    public class Korisnik : Osoba
    {
        private static readonly string fajl = Path.Combine("..", "..", "..", "Data", "Korisnici.json");
        private bool blokiran;
        private List<Playlista> svePlayliste;
        private List<ElementSistema> omiljeno;
        public List<Playlista> SvePlayliste { get; set; }
        public List<ElementSistema> Omiljeno { get; set; }
        public bool Blokiran { get; set; } = false;

        //base konstruktor
        public Korisnik()
            :base()
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
        //citanje korisnike iz fajla
        public static Dictionary<string, Korisnik> UcitajKorisnike() 
        {
            Dictionary<string, Korisnik> sviKorisnici = new Dictionary<string, Korisnik>();
            try
            {
                string data = File.ReadAllText(fajl);
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Converters.Add(new ElementSistemaConverter());
                sviKorisnici = JsonConvert.DeserializeObject<Dictionary<string, Korisnik>>(data, settings);
            }
            catch (IOException ex) 
            {
                throw new Exception("Greska pri citanju fajla!");
            }
            return sviKorisnici;
        }
        //pisanje korisnika u fajl
        public static void UpisiKorisnike(Dictionary<string, Korisnik> sviKorisnici) 
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                string data = JsonConvert.SerializeObject(sviKorisnici, settings);
                File.WriteAllText(fajl, data);
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception("Greska pri upisu u fajl!");
            }
        }
        //Dodaj korisnika
        public void Dodaj() 
        { 
            Dictionary<string, Korisnik> sviKorisnici = UcitajKorisnike();
            if (sviKorisnici.ContainsKey(Id))
            {
                throw new Exception("Korisnik vec postoji!");
            }

            sviKorisnici[Id] = this;
            UpisiKorisnike(sviKorisnici);
        }
        //Izmeni korisnika
        public void Izmeni(string ime, string prezime, string telefon, 
            List<Recenzija> sveRecenzije, List<Playlista> svePlayliste, List<ElementSistema> omiljeno) 
        {
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            SvePlayliste = svePlayliste;
            Omiljeno = omiljeno;
            SveRecenzije = sveRecenzije;

            Dictionary<string, Korisnik> sviKorisnici = UcitajKorisnike();
            if (!sviKorisnici.ContainsKey(Id))
            { 
                throw new Exception("Ne postoji trazeni korisnik!");
            }
            sviKorisnici[Id] = this;
            UpisiKorisnike(sviKorisnici);
        }
        //Obrisi korisnika
        public void Obrisi() 
        {
            Dictionary<string, Korisnik> sviKorisnici = UcitajKorisnike();
            if (!sviKorisnici.ContainsKey(Id)) 
            {
                throw new Exception("Ne postoji trazeni korisnik!");
            }

            sviKorisnici.Remove(Id);
            UpisiKorisnike(sviKorisnici);
        }
        //dodavanje elementa u omiljene
        public void OznaciKaoOmiljeno(ElementSistema omiljeniElement)
        {
            Dictionary<string, Korisnik> sviKorisnici = UcitajKorisnike();
            if (Omiljeno.Contains(omiljeniElement))
            { 
                throw new Exception("Element je vec u omiljenim");
            }
            Omiljeno.Add(omiljeniElement);
            sviKorisnici[Id] = this;
            UpisiKorisnike(sviKorisnici);
        }
        //ukloni element iz omiljenih
        public void UkloniOmiljeno(ElementSistema omiljeniElement)
        {
            Dictionary<string, Korisnik> sviKorisnici = UcitajKorisnike();
            if (!sviKorisnici[Id].Omiljeno.Contains(omiljeniElement))
            {
                throw new Exception("Element nije medju omiljenima");
            }
            Omiljeno.Remove(omiljeniElement);
            sviKorisnici[Id] = this;
            UpisiKorisnike(sviKorisnici);
        }
        //Dodavanje nove recenzije
        public void OstaviRecenziju(string opis, int ocena, ElementSistema recenziraniElement)
        {
            Recenzija novaRecenzija = new Recenzija(opis, ocena, this, recenziraniElement);
            if (SveRecenzije.Contains(novaRecenzija))
            { 
                throw new Exception("Vec ste ostavili recenziju na ovaj element");
            }
            novaRecenzija.Dodaj();
            Dictionary<string, Korisnik> sviKorisnici = UcitajKorisnike();
            sviKorisnici[Id].SveRecenzije.Add(novaRecenzija);
            UpisiKorisnike(sviKorisnici);
        }
        //Dodaj playlistu
        public void KreirajPlaylistu(string ime, string status)
        {
            Playlista novaPlaylista = new Playlista(status, ime, this);
            novaPlaylista.Dodaj(this);
        }
        //Dodavanje numere na playlistu
        public void DodajNumeruNaPlaylistu(MuzickaNumera numera, int idPlayliste)
        {
            foreach (Playlista playlista in SvePlayliste)
            {
                if (playlista.Id != idPlayliste)
                {
                    continue;
                }
                playlista.DodajNumeru(numera);
                Dictionary<string, Korisnik> sviKorisnici = UcitajKorisnike();
                sviKorisnici[Id] = this;
                UpisiKorisnike(sviKorisnici);
            }
        }
        //Uklanjanje numere sa playliste
        public void UkloniNumeruSaPlayliste(MuzickaNumera numera, int idPlayliste)
        {
            foreach (Playlista playlista in SvePlayliste)
            { 
                if(playlista.Id != idPlayliste)
                { 
                    continue; 
                }
                playlista.UkloniNumeru(numera);
                Dictionary<string, Korisnik> sviKorisnici = UcitajKorisnike();
                sviKorisnici[Id] = this;
                UpisiKorisnike(sviKorisnici);
            }
        }
        //Glasaj
        public void Glasaj() { }
    }
}
