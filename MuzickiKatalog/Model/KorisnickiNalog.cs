using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MuzickiKatalog.Model
{
    class KorisnickiNalog
    {
        private static readonly string fajl = Path.Combine("..", "..", "..", "Data", "KorisnickiNalozi.json");

        private string korisnickoIme;
        private string lozinka;
        private VrstaKorisnika vrstaKorisnika;

        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public VrstaKorisnika VrstaKorisnika { get; set; }
        public KorisnickiNalog() { }
        public KorisnickiNalog(string _korisnickoIme, string _lozinka, VrstaKorisnika _vrstaKorisnika)
        {
            KorisnickoIme = _korisnickoIme;
            Lozinka = _lozinka;
            VrstaKorisnika = _vrstaKorisnika;
        }
        //citaj korisnicke naloge iz fajla
        public static Dictionary<string, KorisnickiNalog> UcitajKorisnickeNaloge()
        {
            Dictionary<string, KorisnickiNalog> sviKorisnickiNalozi = new Dictionary<string, KorisnickiNalog>();
            try
            {
                string data  = File.ReadAllText(fajl);
                sviKorisnickiNalozi = JsonConvert.DeserializeObject<Dictionary<string, KorisnickiNalog>>(data);
            }
            catch(IOException e)
            {
                throw new Exception("Greska pri citanju iz fajla");
            }
            return sviKorisnickiNalozi;
        }
        //pisanje korisnickog naloga u fajl
        public static void UpisiKorisnickeNaloge(Dictionary<string,KorisnickiNalog> sviKorisnickiNalozi)
        {
            try
            {
                string data = JsonConvert.SerializeObject(sviKorisnickiNalozi,Formatting.Indented);
                File.WriteAllText(fajl,data);
            }
            catch(FileNotFoundException e)
            {
                throw new Exception("Greska pri upisivanju u fajl");
            }
        }
        //dodaj korisnicki nalog
        public void Dodaj()
        {
            Dictionary<string, KorisnickiNalog> sviKorisnickiNalozi = UcitajKorisnickeNaloge();
            if (sviKorisnickiNalozi.ContainsKey(KorisnickoIme))
            {
                throw new Exception("Korisnicki nalog vec postoji");
            }
            sviKorisnickiNalozi[KorisnickoIme] = this;
            UpisiKorisnickeNaloge(sviKorisnickiNalozi);
        }
        //izmena lozinke na korisnickom nalogu
        public void Izmeni(string _korisnickoIme,string _lozinka)
        {
            KorisnickoIme = _korisnickoIme;
            Lozinka = _lozinka;

            Dictionary<string, KorisnickiNalog> sviKorisnickiNalozi = UcitajKorisnickeNaloge();
            if (!sviKorisnickiNalozi.ContainsKey(KorisnickoIme))
            {
                throw new Exception("Ne postoji trazeni korisnicki nalog");
            }
            sviKorisnickiNalozi[KorisnickoIme] = this;
            UpisiKorisnickeNaloge(sviKorisnickiNalozi);
        }
        //brisanje korisnickog naloga
        public void Obrisi()
        {
            Dictionary<string, KorisnickiNalog> sviKorisnickiNalozi = UcitajKorisnickeNaloge();
            if (!sviKorisnickiNalozi.ContainsKey(KorisnickoIme))
            {
                throw new Exception("Ne postoji trazeni korisnicki nalog");
            }
            sviKorisnickiNalozi.Remove(KorisnickoIme);
            UpisiKorisnickeNaloge(sviKorisnickiNalozi);
        }
        public static Osoba Login(string _korisnickoIme, string _lozinka)
        {
            Dictionary<string, KorisnickiNalog> sviKorisnickiNalozi = UcitajKorisnickeNaloge();
            if (sviKorisnickiNalozi.ContainsKey(_korisnickoIme))
            {
                if(sviKorisnickiNalozi[_korisnickoIme].Lozinka == _lozinka)
                {

                }
                
            }
            return new Korisnik();
        }
        public static Korisnik Register(string _ime, string _prezime, string _email, string _telefon, string _lozinka)
        {
            Korisnik k = new Korisnik(_ime, _prezime, _email, _telefon, _email);
            KorisnickiNalog kn = new KorisnickiNalog(_email, _lozinka, VrstaKorisnika.korisnik);
            kn.Dodaj();
            
            return k;
        }
        public static void Logout()
        {

        }
    }
}
