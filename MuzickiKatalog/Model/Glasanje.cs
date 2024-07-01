using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Glasanje
    {
        private static readonly string fajl = Path.Combine("..", "..", "..", "Data", "Glasanja.json");
        private int id;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private string imeTakmicenja;
        private List<ElementSistema> kandidati;
        private List<Glas> glasovi;

        public int Id { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public string ImeTakmicenja { get; set; }
        public List<ElementSistema> Kandidati { get; set; }
        public List<Glas> Glasovi { get; set; }
        //base konstruktor
        public Glasanje() 
        { 
            Kandidati = new List<ElementSistema>();
            Glasovi = new List<Glas>();
        }
        //parametarski konstruktor
        public Glasanje(int _id, DateTime _datumPocetka, DateTime _datumZavrsetka, string _imeTakmicenja)
        { 
            Id = _id;
            DatumPocetka = _datumPocetka;
            DatumZavrsetka = _datumZavrsetka;
            imeTakmicenja = _imeTakmicenja;
        }
        //parametarski konstruktor sa inicijalizovanim listama
        public Glasanje(int _id, DateTime _datumPocetka, DateTime _datumZavrsetka, string _imeTakmicenja,
            List<ElementSistema> _kandidati, List<Glas> _glasovi)
        {
            Id = _id;
            DatumPocetka = _datumPocetka;
            DatumZavrsetka = _datumZavrsetka;
            imeTakmicenja = _imeTakmicenja;
            Kandidati = _kandidati;
            Glasovi = _glasovi;
        }
        //citanje glasanja iz fajla
        public static Dictionary<int, Glasanje> UcitajGlasanja() 
        {
            Dictionary<int, Glasanje> svaGlasanja = new Dictionary<int, Glasanje>();
            try
            {
                string data = File.ReadAllText(fajl);
                svaGlasanja = JsonConvert.DeserializeObject<Dictionary<int, Glasanje>>(data);
            }
            catch (IOException ex)
            {
                throw new Exception("Greska kod ucitavanja fajla!");
            }
            return svaGlasanja;
        }
        //pisanje glasanja u fajl
        public static void UpisiGlasanja(Dictionary<int, Glasanje> svaGlasanja)
        {
            try
            {
                string data = JsonConvert.SerializeObject(svaGlasanja, Formatting.Indented);
                File.WriteAllText(fajl, data);
            }
            catch (IOException ex)
            {
                throw new Exception("Greska kod citanja iz fajla!");
            }
        }
        //dodaj glasanje
        public void Dodaj() 
        {
            Dictionary<int, Glasanje> svaGlasanja = UcitajGlasanja();
            if (svaGlasanja.ContainsKey(Id))
            {
                throw new Exception("Glasanje vec postoji!");
            }
            svaGlasanja[Id] = this;
            UpisiGlasanja(svaGlasanja);
        }
        //izmeni glasanje
        public void Izmeni(DateTime datumPocetka, DateTime datumZavrsetka, string imeTakmicenja) 
        {
            DatumPocetka = datumPocetka;
            DatumZavrsetka = datumZavrsetka;
            ImeTakmicenja = imeTakmicenja;

            Dictionary<int, Glasanje> svaGlasanja = UcitajGlasanja();
            if (!svaGlasanja.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazeno glasanje");
            }
            svaGlasanja[Id] = this;
            UpisiGlasanja(svaGlasanja);
        }
        //obrisi glasanje
        public void Obrisi() 
        {
            Dictionary<int, Glasanje> svaGlasanja = UcitajGlasanja();
            if (!svaGlasanja.ContainsKey(Id))
            { 
                throw new Exception("Ne postoji trazeno glasanje!");
            }
            svaGlasanja.Remove(Id);
            UpisiGlasanja(svaGlasanja);
        }
    }
}
