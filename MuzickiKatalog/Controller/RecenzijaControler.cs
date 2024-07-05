using MuzickiKatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Controller
{
    public class RecenzijaControler
    {
        public static ElementSistema DodajRecenziju(string opis, int ocena, string recezent, int recenziraniElement)
        {
            if (ocena < 1 || ocena > 5) 
            {
                throw new Exception("Ocena mora biti 1-5!");
            }
            if (opis == null || opis == "") 
            {
                throw new Exception("Niste dodati opis recenzije!");
            }

            Recenzija recenzija = new Recenzija(opis, ocena, recezent, recenziraniElement);
            recenzija.Dodaj();

            Dictionary<int, Album> sviAlbumi = Album.UcitajAlbume();
            Dictionary<int, Koncert> sviKoncerti = Koncert.UcitajKoncerte();
            Dictionary<int, Izvodjac> sviIzvodjaci = Izvodjac.UcitajIzvodjace();
            Dictionary<int, MuzickaGrupa> sveGrupe = MuzickaGrupa.UcitajMuzickeGrupe();
            Dictionary<int, MuzickaNumera> sveNumere = MuzickaNumera.UcitajMuzickeNumere();

            if (sviAlbumi.ContainsKey(recenziraniElement))
            {
                sviAlbumi[recenziraniElement].SveRecenzije.Add(recenzija);
                Album.UpisiAlbume(sviAlbumi);
                return sviAlbumi[recenziraniElement];
            }
            else if (sviKoncerti.ContainsKey(recenziraniElement))
            {
                sviKoncerti[recenziraniElement].SveRecenzije.Add(recenzija);
                Koncert.UpisiKoncerte(sviKoncerti);
                return sviKoncerti[recenziraniElement];
            }
            else if (sviIzvodjaci.ContainsKey(recenziraniElement))
            {
                sviIzvodjaci[recenziraniElement].SveRecenzije.Add(recenzija);
                Izvodjac.UpisiIzvodjace(sviIzvodjaci);
                return sviIzvodjaci[recenziraniElement];
            }
            else if (sveGrupe.ContainsKey(recenziraniElement))
            {
                sveGrupe[recenziraniElement].SveRecenzije.Add(recenzija);
                MuzickaGrupa.UpisiMuzickeGrupe(sveGrupe);
                return sveGrupe[recenziraniElement];
            }
            else if(sveNumere.ContainsKey(recenziraniElement))
            {
                sveNumere[recenziraniElement].SveRecenzije.Add(recenzija);
                MuzickaNumera.UpisiMuzickeNumere(sveNumere);
                return sveNumere[recenziraniElement];
            }
            return null;
        }
    }
}
