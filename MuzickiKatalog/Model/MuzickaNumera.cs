using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MuzickiKatalog.Model
{
    public class MuzickaNumera : ElementSistema
    {
        private static readonly string file = Path.Combine("..", "..", "..", "Data", "MuzickeNumere.json");
        private DateTime datumIzbacivanja;
        private List<ElementSistema> izvodjaci;

        public DateTime DatumIzbacivanja { get; set; }
        public List<Izvodjac> Izvodjaci { get; set; }
        //base konstruktor
        public MuzickaNumera()
            :base()
        { 
            Izvodjaci = new List<Izvodjac>();
        }
        //parametarski konstruktor
        public MuzickaNumera(string _ime, int _prosecnaOcena, string _opis, int _id, DateTime _datumIzbacivanja)
            :base(_ime, _prosecnaOcena, _opis, _id)
        { 
            DatumIzbacivanja = _datumIzbacivanja;
            Izvodjaci = new List<Izvodjac>();
        }
        //parametarski konstruktor sa inicijalizovanim listama
        public MuzickaNumera(string _ime, int _prosecnaOcena, string _opis, int _id, DateTime _datumIzbacivanja,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<Izvodjac> _izvodjaci)
            : base(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije)
        {
            DatumIzbacivanja = _datumIzbacivanja;
            Izvodjaci = _izvodjaci;
        }
        //citanje muzicke numere iz fajla
        public static Dictionary<int,MuzickaNumera> UcitajMuzickeNumere()
        {
            Dictionary<int, MuzickaNumera> sveMuzickeNumere = new Dictionary<int, MuzickaNumera>();
            try 
            {
                string data = File.ReadAllText(file);
                sveMuzickeNumere = JsonConvert.DeserializeObject<Dictionary<int, MuzickaNumera>>(data);
            } 
            catch(IOException e)
            {
                throw new Exception("Greska pri citanju iz fajla");
            }
            return sveMuzickeNumere;
        }
        //pisanje muzicke numere u fajl;
        public static void  UpisiMuzickeNumere(Dictionary<int,MuzickaNumera> _sveMuzickeNumere)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                string data = JsonConvert.SerializeObject(_sveMuzickeNumere, settings);
                File.WriteAllText(file, data);
            }
            catch(FileNotFoundException e)
            {
                throw new Exception("Greska pri upisivanju u fajl");
            }
        }
        //dodavanje muzicke numere
        public void Dodaj()
        {
            Dictionary<int, MuzickaNumera> sveMuzickeNumere = UcitajMuzickeNumere();
            if (sveMuzickeNumere == null)
            {
                sveMuzickeNumere = new Dictionary<int, MuzickaNumera>();
            }
            if (sveMuzickeNumere.ContainsKey(Id))
            {
                throw new Exception("Izvodjac vec postoji");
            }
            sveMuzickeNumere[Id] = this;
            UpisiMuzickeNumere(sveMuzickeNumere);
        }
        //izmena muzicke numere
        public void Izmeni(string _ime, int _prosecnaOcena, string _opis, DateTime _datumIzbacivanja,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<Izvodjac> _izvodjaci)
        {
            Ime = _ime;
            ProsecnaOcena = _prosecnaOcena;
            Opis = _opis;
            DatumIzbacivanja = _datumIzbacivanja;
            SviZanrovi = _sviZanrovi;
            SveRecenzije = _sveRecenzije;
            Izvodjaci = _izvodjaci;

            Dictionary<int, MuzickaNumera> sveMuzickeNumere = UcitajMuzickeNumere();
            if (!sveMuzickeNumere.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazena muzicka numera");
            }
            sveMuzickeNumere[Id] = this;
            UpisiMuzickeNumere(sveMuzickeNumere);
        }
        //brisanje muzicke numere
        public void Obrisi()
        {
            Dictionary<int, MuzickaNumera> sveMuzickeNumere= UcitajMuzickeNumere();
            if (!sveMuzickeNumere.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeni izvodjac");
            }
            sveMuzickeNumere.Remove(Id);
            UpisiMuzickeNumere(sveMuzickeNumere);
        }
    }
}
