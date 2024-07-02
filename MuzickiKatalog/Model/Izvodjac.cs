using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuzickiKatalog.Model
{
    public class Izvodjac : ElementSistema
    {
        private static readonly string file = Path.Combine("..", "..", "..", "Data", "Izvodjaci.json");
        private List<MuzickaNumera> numere;
        private MuzickaGrupa grupa;

        public List<MuzickaNumera> Numere { get; set; }
        public MuzickaGrupa Grupa { get; set; }
        //base konstruktor
        public Izvodjac() 
            :base()
        {
            Grupa = null;
            Numere = new List<MuzickaNumera>();
        }
        //parametarski konstruktor
        public Izvodjac(string _ime, int _prosecnaOcena, string _opis, int _id, MuzickaGrupa _muzickaGrupa)
            : base(_ime, _prosecnaOcena, _opis, _id)
        {
            Grupa = _muzickaGrupa;
            Numere = new List<MuzickaNumera>();
        }
        //parametarski konstruktor sa inicijalizovanom listom
        public Izvodjac(string _ime, int _prosecnaOcena, string _opis, int _id, MuzickaGrupa _muzickaGrupa,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<MuzickaNumera> _numere)
            : base(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije)
        { 
            Grupa = _muzickaGrupa;
            Numere = _numere;
        }
        //citanje izvodjaca iz fajla
        public static Dictionary<int, Izvodjac> UcitajIzvodjace()
        {
            Dictionary<int, Izvodjac> sviIzvodjaci = new Dictionary<int, Izvodjac>();
            try
            {
                string data = File.ReadAllText(file);
                sviIzvodjaci = JsonConvert.DeserializeObject<Dictionary<int, Izvodjac>>(data);
            }
            catch(IOException e)
            {
                throw new Exception("Greska pri citanju iz fajla");
            }
            return sviIzvodjaci; 
        }
        //pisanje izvodjaca u fajl
        public static void UpisiIzvodjace(Dictionary<int,Izvodjac> _sviIzvodjaci)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                string data = JsonConvert.SerializeObject(_sviIzvodjaci, settings);
                File.WriteAllText(file, data);
            }
            catch(FileNotFoundException e)
            {
                throw new Exception("Greska pri upisivanju u fajl");
            }
        }
        //dodavanje izvodjaca
        public void Dodaj()
        {
            Dictionary<int, Izvodjac> sviIzvodjaci = UcitajIzvodjace();
            if (sviIzvodjaci == null)
            {
                sviIzvodjaci = new Dictionary<int, Izvodjac>();
            }
            if (sviIzvodjaci.ContainsKey(Id))
            {
                throw new Exception("Izvodjac vec postoji");
            }
            sviIzvodjaci[Id] = this;
            UpisiIzvodjace(sviIzvodjaci);
        }
        //izmeni izvodjaca
        public void Izmeni(string _ime, int _prosecnaOcena, string _opis, MuzickaGrupa _muzickaGrupa,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<MuzickaNumera> _numere)
        {
            Ime = _ime;
            ProsecnaOcena = _prosecnaOcena;
            Opis = _opis;
            Grupa = _muzickaGrupa;
            SviZanrovi = _sviZanrovi;
            SveRecenzije = _sveRecenzije;
            Numere = _numere;

            Dictionary<int, Izvodjac> sviIzvodjaci = UcitajIzvodjace();
            if (!sviIzvodjaci.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeni izvodjac");
            }
            sviIzvodjaci[Id] = this;
            UpisiIzvodjace(sviIzvodjaci);
        }
        //obrisi izvodjaca
        public void Obrisi()
        {
            Dictionary<int, Izvodjac> sviIzvodjaci = UcitajIzvodjace();
            if (!sviIzvodjaci.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeni izvodjac");
            }
            sviIzvodjaci.Remove(Id);
            UpisiIzvodjace(sviIzvodjaci);
        }
    }
}
