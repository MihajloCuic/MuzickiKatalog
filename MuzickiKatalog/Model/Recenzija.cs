using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickiKatalog.Helpers;

namespace MuzickiKatalog.Model
{
    public class Recenzija
    {
        private static readonly string fajl = Path.Combine("..", "..", "..", "Data", "Recenzije.json");
        private int id;
        private string opis;
        private double ocena;
        private Osoba recezent;
        private ElementSistema recenziraniElement;

        public int Id { get; set; }
        public string Opis { get; set; }
        public int Ocena { get; set; }
        public Osoba Recezent { get; set; }
        public ElementSistema RecenziraniElement { get; set; }
        //base konstruktor
        public Recenzija() { }
        //parametarski konstruktor
        public Recenzija(string _opis, int _ocena, Osoba _recezent, ElementSistema _recenziraniElement)
        {
            Id = PomocneFunkcije.NapraviID(_recezent.Id, _recenziraniElement.Id);
            Opis = _opis;
            Ocena = _ocena;
            Recezent = _recezent;
            RecenziraniElement = _recenziraniElement;
        }
        //Citanje iz fajla
        public static Dictionary<int, Recenzija> UcitajRecenzije() 
        {
            Dictionary<int, Recenzija> sveRecenzije = new Dictionary<int, Recenzija>();
            try
            {
                string data = File.ReadAllText(fajl);
                sveRecenzije = JsonConvert.DeserializeObject<Dictionary<int, Recenzija>>(data);
            }
            catch (IOException ex)
            {
                throw new Exception("Greska pri citanju fajla!");
            }
            return sveRecenzije;
        }
        //Pisanje u fajl
        public static void UpisiRecenzije(Dictionary<int, Recenzija> sveRecenzije)
        {
            try
            {
                string data = JsonConvert.SerializeObject(sveRecenzije, Formatting.Indented);
                File.WriteAllText(fajl, data);
            }
            catch (IOException ex)
            {
                throw new Exception("Greska pri upisu u fajl!");
            }
        }
        //Dodaj recenziju
        public void Dodaj() 
        {
            Dictionary<int, Recenzija> sveRecenzije = UcitajRecenzije();
            if (sveRecenzije.ContainsKey(Id))
            {
                throw new Exception("Recenzija vec postoji!");
            }
            sveRecenzije[Id] = this;
            UpisiRecenzije(sveRecenzije);
        }
        //Izmeni recenziju
        public void Izmeni(string opis, int ocena) 
        {
            Opis = opis;
            Ocena = ocena;

            Dictionary<int, Recenzija> sveRecenzije = UcitajRecenzije();
            if (!sveRecenzije.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazena recenzija!");
            }
            sveRecenzije[Id] = this;
            UpisiRecenzije(sveRecenzije);
        }
        //Obrisi recenziju
        public void Obrisi() 
        {
            Dictionary<int, Recenzija> sveRecenzije = UcitajRecenzije();
            if (!sveRecenzije.ContainsKey(Id))
            {
                throw new Exception("Ne postoji trazena recenzija!");
            }
            sveRecenzije.Remove(Id);
            UpisiRecenzije(sveRecenzije);
        }
    }
}
