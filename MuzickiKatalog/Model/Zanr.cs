using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MuzickiKatalog.Model
{
    public class Zanr
    {
        private static readonly string fajl = Path.Combine("..", "..", "..", "Data", "Zanrovi.json");
        private int id;
        private string naziv;

        public int Id { get; set; }
        public string Naziv { get; set; }

        public Zanr() { }
        public Zanr(int _id, string _naziv)
        {
            Id = _id;
            Naziv = _naziv;
        }
        //citaj zanr iz fajla
        public static Dictionary<int, Zanr> UcitajZanrove()
        {
            Dictionary<int, Zanr> sviZanrovi = new Dictionary<int, Zanr>();
            try
            {
                string data = File.ReadAllText(fajl);
                sviZanrovi = JsonConvert.DeserializeObject<Dictionary<int, Zanr>>(data);
            }
            catch (IOException e)
            {
                throw new Exception("Greska pri citanju iz fajla");
            }
            return sviZanrovi;
        }
        //pisi zanrove iz fajla
        public static void UpisiZanrove(Dictionary<int, Zanr> _zanrovi)
        {
            try
            {
                string data = JsonConvert.SerializeObject(_zanrovi, Formatting.Indented);
                File.WriteAllText(fajl, data);
            }
            catch (FileNotFoundException e) { throw new Exception("Greska pri upisivanju u fajl"); }
        }
        //dodaj zanr
        public void Dodaj()
        {
            Dictionary<int, Zanr> sviZanrovi = UcitajZanrove();
            if (sviZanrovi == null) { sviZanrovi = new Dictionary<int, Zanr>(); }
            if (sviZanrovi.ContainsKey(Id)) { throw new Exception("Zanr vec postoji"); }
            sviZanrovi[Id] = this;
            UpisiZanrove(sviZanrovi);
        }
        //izmeni zanr
        public void Izmeni(string _naziv)
        {
            Naziv = _naziv;

            Dictionary<int, Zanr> sviZanrovi = UcitajZanrove();
            if (sviZanrovi == null) { sviZanrovi = new Dictionary<int, Zanr>(); }
            if (!sviZanrovi.ContainsKey(Id)) { throw new Exception("Ne postoji trazeni zanr"); }
            sviZanrovi[Id] = this;
            UpisiZanrove(sviZanrovi);
        }
        //obrisi zanr
        public void Obrisi()
        {
            Dictionary<int, Zanr> sviZanrovi = UcitajZanrove();
            if (!sviZanrovi.ContainsKey(Id)) { throw new Exception("Trazeni zanr ne postoji"); }
            sviZanrovi.Remove(Id);
            UpisiZanrove(sviZanrovi);
        }
    }
}