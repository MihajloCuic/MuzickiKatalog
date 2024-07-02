using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MuzickiKatalog.Model
{
    public class MuzickaGrupa : ElementSistema
    {
        private static readonly string file = Path.Combine("..", "..", "..", "Data", "MuzickeGrupe.json");
        private List<Izvodjac> izvodjaci;
        private List<MuzickaNumera> numere;

        public List<Izvodjac> Izvodjaci { get; set; }
        public List<MuzickaNumera> Numere { get; set; }
        //base konstruktor
        public MuzickaGrupa()
            :base() 
        {
            Izvodjaci = new List<Izvodjac>();
            Numere = new List<MuzickaNumera>();
        }
        //parametarski konstruktor
        public MuzickaGrupa(string _ime, int _prosecnaOcena, string _opis, int _id)
            : base(_ime, _prosecnaOcena, _opis, _id)
        {
            Izvodjaci = new List<Izvodjac>();
            Numere = new List<MuzickaNumera>();
        }
        //parametarski konstruktor sa inicijalizovanom listom
        public MuzickaGrupa(string _ime, int _prosecnaOcena, string _opis, int _id,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<Izvodjac> _izvodjaci, List<MuzickaNumera> _numere)
            : base(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije)
        { 
            Izvodjaci = _izvodjaci;
            Numere = _numere;
        }
        //citanje muzicke gruppe iz fajla
        public static Dictionary<int,MuzickaGrupa> UcitajMuzickeGrupe()
        {
            Dictionary<int, MuzickaGrupa> sveMuzickeGrupe = new Dictionary<int, MuzickaGrupa>();
            try
            {
                string data = File.ReadAllText(file);
                sveMuzickeGrupe = JsonConvert.DeserializeObject<Dictionary<int, MuzickaGrupa>>(data);
            }
            catch(IOException e)
            {
                throw new Exception("Greska pri citanju iz fajla");
            }
            return sveMuzickeGrupe;
        }
        //pisanje muzicke grupe u fajl
        public static void UpisiMuzickeGrupe(Dictionary<int,MuzickaGrupa> _sveMuzickeGrupe)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                string data = JsonConvert.SerializeObject(_sveMuzickeGrupe, settings);
                File.WriteAllText(file, data);
            }
            catch(FileNotFoundException e)
            {
                throw new Exception("Greska pri pisanju u fajl");
            }
        }
        //dodavanje muzivke grupe
        public void Dodaj()
        {
            Dictionary<int, MuzickaGrupa> sveMuzickeGrupe = UcitajMuzickeGrupe();
            if (sveMuzickeGrupe == null)
            {
                sveMuzickeGrupe = new Dictionary<int, MuzickaGrupa>();
            }
            if (sveMuzickeGrupe.ContainsKey(Id))
            {
                throw new Exception("Muzicka grupa vec postoji");
            }
            sveMuzickeGrupe[Id] = this;
            UpisiMuzickeGrupe(sveMuzickeGrupe);
        }
        //izmena muzicke grupe
        public void Izmeni(string _ime, int _prosecnaOcena, string _opis,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<Izvodjac> _izvodjaci, List<MuzickaNumera> _numere)
        {
            Ime = _ime;
            ProsecnaOcena = _prosecnaOcena;
            Opis = _opis;
            SviZanrovi = _sviZanrovi;
            SveRecenzije = _sveRecenzije;
            Izvodjaci = _izvodjaci;
            Numere = _numere;

            Dictionary<int, MuzickaGrupa> sveMuzickeGrupe = UcitajMuzickeGrupe();
            if (!sveMuzickeGrupe.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazena muzicka grupa");
            }
            sveMuzickeGrupe[Id] = this;
            UpisiMuzickeGrupe(sveMuzickeGrupe);
        }
        //brisanje muzicke grupe
        public void Obrisi()
        {
            Dictionary<int, MuzickaGrupa> sveMuzickeGrupe = UcitajMuzickeGrupe();
            if (!sveMuzickeGrupe.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazena muzicka grupa");
            }
            sveMuzickeGrupe.Remove(Id);
            UpisiMuzickeGrupe(sveMuzickeGrupe);
        }
    }
}
