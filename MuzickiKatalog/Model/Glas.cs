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
            Id = _glasac.Id;
            Glasac = _glasac;
            IzglasaniElement = _izglasaniElement;
        }
        //dodaj glas
        public void Dodaj(Glasanje glasanje) 
        {
            if (glasanje.Glasovi.Contains(this))
            {
                throw new Exception("Glas vec postoji");
            }
            glasanje.Glasovi.Add(this);
            Dictionary<int, Glasanje> svaGlasanja = Glasanje.UcitajGlasanja();
            svaGlasanja[glasanje.Id] = glasanje;
            Glasanje.UpisiGlasanja(svaGlasanja);
        }
        //izmeni glas
        public void Izmeni(ElementSistema izglasaniElement, Glasanje glasanje) 
        { 
            if (!glasanje.Glasovi.Contains(this))
            { 
                throw new Exception("Glas ne postoji");
            }
            foreach (Glas glas in glasanje.Glasovi)
            {
                if (glas.Id == Id)
                {
                    glas.IzglasaniElement = izglasaniElement;
                    break;
                }
            }
            Dictionary<int, Glasanje> svaGlasanja = Glasanje.UcitajGlasanja();
            svaGlasanja[glasanje.Id] = glasanje;
            Glasanje.UpisiGlasanja(svaGlasanja);
        }
        //obrisi glas
        public void Obrisi(Glasanje glasanje) 
        {
            if (!glasanje.Glasovi.Contains(this))
            { 
                throw new Exception("Glas ne postoji");
            }
            glasanje.Glasovi.Remove(this);
            Dictionary<int, Glasanje> svaGlasanja = Glasanje.UcitajGlasanja();
            svaGlasanja[glasanje.Id] = glasanje;
            Glasanje.UpisiGlasanja(svaGlasanja);
        }
    }
}
