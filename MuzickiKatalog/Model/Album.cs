using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace MuzickiKatalog.Model
{
    public class Album : ElementSistema
    {
        private static readonly string file = Path.Combine("..", "..", "..", "Data", "Albumi.json");
        private DateTime datumIzdavanja;
        private List<MuzickaNumera> numereAlbuma;
        private List<Izvodjac> izvodjaci;

        public DateTime DatumIzdavanja { get; set; }
        public List<MuzickaNumera> NumereAlbuma { get; set; }
        public List<Izvodjac> Izvodjaci { get; set; }

        //base konstruktor
        public Album() 
            :base()
        {
            NumereAlbuma = new List<MuzickaNumera>();
            Izvodjaci = new List<Izvodjac>();
        }
        //parametarski konstruktor
        public Album(string _ime, int _prosecnaOcena, string _opis, int _id, DateTime _datumIzdavanja)
            : base(_ime, _prosecnaOcena, _opis, _id)
        { 
            DatumIzdavanja = _datumIzdavanja;
            NumereAlbuma = new List<MuzickaNumera>();
            Izvodjaci = new List<Izvodjac>();
        }
        //parametarski konstruktor sa inicijalizovanim listama
        public Album(string _ime, int _prosecnaOcena, string _opis, int _id, DateTime _datumIzdavanja, 
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<MuzickaNumera> _numereAlbuma, List<Izvodjac> _izvodjaci)
            : base(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije)
        {
            DatumIzdavanja = _datumIzdavanja;
            NumereAlbuma = _numereAlbuma;
            Izvodjaci = _izvodjaci;
        }
        //citanje albuma iz fajla
        public static Dictionary<int,Album> UcitajAlbume()
        {
            Dictionary<int,Album> sviAlbumi = new Dictionary<int,Album>();
            try
            {
                string data = File.ReadAllText(file);
                sviAlbumi = JsonConvert.DeserializeObject<Dictionary<int, Album>>(data);
            }
            catch(IOException e)
            {
                throw new Exception("Greska pri citanju iz fajla");
            }
            return sviAlbumi;
        }
        //pisanje albuma u fajl
        public static void UpisiAlbume(Dictionary<int,Album> sviAlbumi)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                string data = JsonConvert.SerializeObject(sviAlbumi,settings);
                File.WriteAllText(file, data);
            }
            catch(FileNotFoundException e)
            {
                throw new Exception("Greska pri upisivanju u fajl");
            }
        }
        //dodavanje albuma
        public void Dodaj()
        {
            Dictionary<int, Album> sviAlbumi = UcitajAlbume();
            if (sviAlbumi == null)
            {
                sviAlbumi = new Dictionary<int, Album>();
            }
            if (sviAlbumi.ContainsKey(Id))
            {
                throw new Exception("Album vec postoji");
            }
            sviAlbumi[Id] = this;
            UpisiAlbume(sviAlbumi);
        }
        //izmena albuma
        public void Izmeni(string _ime, int _prosecnaOcena, string _opis,  DateTime _datumIzdavanja,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<MuzickaNumera> _numereAlbuma, List<Izvodjac> _izvodjaci)
        {
            Ime = _ime;
            ProsecnaOcena = _prosecnaOcena;
            Opis = _opis;
            DatumIzdavanja = _datumIzdavanja;
            SviZanrovi = _sviZanrovi;
            SveRecenzije = _sveRecenzije;
            NumereAlbuma = _numereAlbuma;
            Izvodjaci = _izvodjaci;

            Dictionary<int, Album> sviAlbumi = UcitajAlbume();
            if (!sviAlbumi.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeni album");
            }
            sviAlbumi[Id] = this;
            UpisiAlbume(sviAlbumi);
        }
        //brisanje albuma
        public void Obrisi()
        {
            Dictionary<int, Album> sviAlbumi = UcitajAlbume();
            if (!sviAlbumi.ContainsKey(Id))
            {
                throw new Exception("Album ne postoji");
            }
            sviAlbumi.Remove(Id);
            UpisiAlbume(sviAlbumi);
        }
    }
}
