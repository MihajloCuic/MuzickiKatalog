using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Glas
    {
        private string id;
        private Osoba glasac;
        private ElementSistema izglasaniElement;

        public string Id { get; set; }
        public Osoba Glasac { get; set; }
        public ElementSistema IzglasaniElement { get; set; }
        //base konstruktor
        public Glas() { }
        //parametarski konstruktor
        public Glas(Osoba _glasac, ElementSistema _izglasaniElement)
        {
            Glasac = _glasac;
            IzglasaniElement = _izglasaniElement;
        }
        //dodaj glas
        public Dictionary<string, Glas> Dodaj(Dictionary<string, Glas> sviGlasovi) 
        {
            if (sviGlasovi.ContainsKey(Id))
            {
                throw new Exception("Glas vec postoji");
            }
            sviGlasovi[Id] = this;
            return sviGlasovi;
        }
        //izmeni glas
        public Dictionary<string, Glas> Izmeni(ElementSistema izglasaniElement, Dictionary<string, Glas> sviGlasovi) 
        { 
            IzglasaniElement = izglasaniElement;

            if (!sviGlasovi.ContainsKey(Id))
            { 
                throw new Exception("Glas ne postoji");
            }
            sviGlasovi[Id] = this;
            return sviGlasovi;
        }
        //obrisi glas
        public Dictionary<string, Glas> Obrisi(Dictionary<string, Glas> sviGlasovi) 
        {
            if (!sviGlasovi.ContainsKey(Id))
            { 
                throw new Exception("Glas ne postoji");
            }
            sviGlasovi.Remove(Id);
            return sviGlasovi;
        }
    }
}
