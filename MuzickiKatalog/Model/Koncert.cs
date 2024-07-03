using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace MuzickiKatalog.Model
{
    public class Koncert : ElementSistema
    {
        private static readonly string file = Path.Combine("..", "..", "..", "Data", "Koncerti.json");
        private string snimatelj;
        private string formatPrikaza;
        private DateTime datumDesavanja;
        private List<ElementSistema> elementiKoncerta;

        public string Snimatelj { get; set; }
        public string FormatPrikaza { get; set; }
        public DateTime DatumDesavanja { get; set; }
        public List<ElementSistema> ElementiKoncerta { get; set; }
        //base konstruktor
        public Koncert() 
            :base()
        {
            ElementiKoncerta = new List<ElementSistema>();
        }
        //parametarski konstruktor
        public Koncert(string _ime, int _prosecnaOcena, string _opis, int _id, string _snimatelj, string _formatPrikaza, DateTime _datumDesavanja)
            : base(_ime, _prosecnaOcena, _opis, _id)
        { 
            Snimatelj = _snimatelj;
            FormatPrikaza = _formatPrikaza;
            DatumDesavanja = _datumDesavanja;
            ElementiKoncerta = new List<ElementSistema>();
        }
        //parametarski konstruktor sa inicijalizovanim listama
        public Koncert(string _ime, int _prosecnaOcena, string _opis, int _id, string _snimatelj, string _formatPrikaza, DateTime _datumDesavanja,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<ElementSistema> _elementiKoncerta)
            : base(_ime, _prosecnaOcena, _opis, _id, _sviZanrovi, _sveRecenzije)
        {
            Snimatelj = _snimatelj;
            FormatPrikaza = _formatPrikaza;
            DatumDesavanja = _datumDesavanja;
            ElementiKoncerta = _elementiKoncerta;
        }

        //citanje koncerta iz fajla
       
        public static Dictionary<int,Koncert> UcitajKoncerte()
        {
            Dictionary<int, Koncert> sviKoncerti = new Dictionary<int, Koncert>();
            try
            {
                string data = File.ReadAllText(file);
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.Converters.Add(new ElementSistemaConverter());
                sviKoncerti = JsonConvert.DeserializeObject<Dictionary<int, Koncert>>(data, settings);
            }
            catch (IOException e)
            {
                throw new Exception("Greska pri citanju iz fajla");
            }
            return sviKoncerti;
        }
        //pisanje koncerta u fajl
        public static void UpisiKoncerte(Dictionary<int,Koncert> sviKoncerti)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                string data = JsonConvert.SerializeObject(sviKoncerti, settings);
                File.WriteAllText(file, data);
            }
            catch(FileNotFoundException e)
            {
                throw new Exception("Greska pri pisanju u fajl");
            }
        }
        //dodaj koncert
        public void Dodaj() 
        {
            Dictionary<int, Koncert> sviKoncerti = UcitajKoncerte();
            if (sviKoncerti == null)
            {
                sviKoncerti = new Dictionary<int, Koncert>();
            }
            if (sviKoncerti.ContainsKey(Id))
            {
                throw new Exception("Koncert vec postoji");
            }
            sviKoncerti[Id] = this;
            UpisiKoncerte(sviKoncerti);
        }
        //izmeni koncert
        public void Izmeni(string _ime, int _prosecnaOcena, string _opis, string _snimatelj, string _formatPrikaza, DateTime _datumDesavanja,
            List<Zanr> _sviZanrovi, List<Recenzija> _sveRecenzije, List<ElementSistema> _elementiKoncerta)
        {
            Ime = _ime;
            ProsecnaOcena = _prosecnaOcena;
            Opis = _opis;
            Snimatelj = _snimatelj;
            FormatPrikaza = _formatPrikaza;
            DatumDesavanja = _datumDesavanja;
            SviZanrovi = _sviZanrovi;
            SveRecenzije = _sveRecenzije;
            ElementiKoncerta = _elementiKoncerta;

            Dictionary<int,Koncert> sviKoncerti = UcitajKoncerte();
            if (!sviKoncerti.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeni koncert");
            }
            sviKoncerti[Id] = this;
            UpisiKoncerte(sviKoncerti);
        }
        //obrisi koncert
        public void Obrisi()
        {
            Dictionary<int, Koncert> sviKoncerti= UcitajKoncerte();
            if (!sviKoncerti.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeni koncert");
            }
            sviKoncerti.Remove(Id);
            UpisiKoncerte(sviKoncerti);
        }
    }
}
