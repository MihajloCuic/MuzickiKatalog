using MuzickiKatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Controller
{
    public class PretragaControler
    {
        public static List<ElementSistema> PronadjiElementeSistema(string naziv)
        {
            List<ElementSistema> pronadjeniElementi = new List<ElementSistema>();
            Dictionary<int, Album> sviAlbumi = Album.UcitajAlbume();
            Dictionary<int, Koncert> sviKoncerti = Koncert.UcitajKoncerte();
            Dictionary<int, Izvodjac> sviIzvodjaci = Izvodjac.UcitajIzvodjace();
            Dictionary<int, MuzickaGrupa> sveGrupe = MuzickaGrupa.UcitajMuzickeGrupe();
            Dictionary<int, MuzickaNumera> sveNumere = MuzickaNumera.UcitajMuzickeNumere();

            foreach (KeyValuePair<int, Album> album in sviAlbumi)
            {
                if (album.Value.Ime == naziv)
                {
                    pronadjeniElementi.Add(album.Value);
                    break;
                }
                foreach (Izvodjac izvodjac in album.Value.Izvodjaci) 
                {
                    if (izvodjac.Ime == naziv)
                    {
                        pronadjeniElementi.Add(album.Value);
                        break;
                    }
                }
                foreach (MuzickaNumera numera in album.Value.NumereAlbuma)
                {
                    if (numera.Ime == naziv)
                    {
                        pronadjeniElementi.Add(album.Value);
                        break;
                    }
                }
            }
            foreach (KeyValuePair<int, Koncert> koncert in sviKoncerti)
            {
                if (koncert.Value.Ime == naziv) 
                {
                    pronadjeniElementi.Add(koncert.Value);
                    break;
                }
                foreach (ElementSistema elementKoncerta in koncert.Value.ElementiKoncerta)
                {
                    if (elementKoncerta.Ime == naziv)
                    {
                        pronadjeniElementi.Add(koncert.Value);
                        break;
                    }
                }
            }
            foreach (KeyValuePair<int, Izvodjac> izvodjac in sviIzvodjaci)
            {
                if (izvodjac.Value.Ime == naziv)
                { 
                    pronadjeniElementi.Add(izvodjac.Value);
                    break;
                }
                foreach (MuzickaNumera numera in izvodjac.Value.Numere)
                {
                    if (numera.Ime == naziv)
                    {
                        pronadjeniElementi.Add(izvodjac.Value);
                    }
                }
            }
            foreach (KeyValuePair<int, MuzickaGrupa> grupa in sveGrupe)
            {
                if (grupa.Value.Ime == naziv)
                {
                    pronadjeniElementi.Add(grupa.Value);
                    break;
                }
                foreach (MuzickaNumera numera in grupa.Value.Numere)
                {
                    if (numera.Ime == naziv)
                    {
                        pronadjeniElementi.Add(grupa.Value);
                    }
                }
                foreach (Izvodjac izvodjac in grupa.Value.Izvodjaci)
                {
                    if (izvodjac.Ime == naziv)
                    {
                        pronadjeniElementi.Add(grupa.Value);
                    }
                }
            }
            foreach (KeyValuePair<int, MuzickaNumera> numera in sveNumere)
            {
                if (numera.Value.Ime == naziv)
                {
                    pronadjeniElementi.Add(numera.Value);
                    break;
                }
                foreach (Izvodjac izvodjac in numera.Value.Izvodjaci)
                {
                    if (izvodjac.Ime == naziv)
                    {
                        pronadjeniElementi.Add(numera.Value);
                    }
                }
            }
            return pronadjeniElementi;
        }
    }
}
