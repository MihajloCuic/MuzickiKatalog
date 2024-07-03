using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickiKatalog.Helpers;

namespace MuzickiKatalog.Model
{
    public class Playlista
    {
        private int id;
        private string ime;
        private Dictionary<int, MuzickaNumera> numere;
        private Status status;

        public int Id { get; set; }
        public string Ime { get; set; }
        public Dictionary<int, MuzickaNumera> Numere { get; set; }
        public Status Status { get; set; }
        //base konstruktor
        public Playlista()
        { 
            numere = new Dictionary<int, MuzickaNumera>();
        }
        //parametarski konstruktor
        public Playlista(string _status, string _ime, Korisnik autorPlayliste)
        {
            Id = PomocneFunkcije.NapraviIDPlaylistu(autorPlayliste.Id, _ime);
            Ime = _ime;
            Status = (Status)Enum.Parse(typeof(Status), _status);
            Numere = new Dictionary<int, MuzickaNumera>();
        }
        //parametarski konstruktor sa inicijalizovanom playlistom
        public Playlista(string _status, string _ime, Korisnik autorPlayliste, Dictionary<int, MuzickaNumera> _numere)
        {
            Id = PomocneFunkcije.NapraviIDPlaylistu(autorPlayliste.Id, _ime);
            Ime = _ime;
            Status = (Status)Enum.Parse(typeof(Status), _status);
            Numere = _numere;
        }
        //dodaje novu playlistu
        public void Dodaj(Korisnik autorPlayliste)
        {
            if (autorPlayliste.SvePlayliste.Contains(this))
            {
                throw new Exception("Vec postoji playlista");
            }
            Dictionary<string, Korisnik> sviKorisnici = Korisnik.UcitajKorisnike();
            sviKorisnici[autorPlayliste.Id].SvePlayliste.Add(this);
            Korisnik.UpisiKorisnike(sviKorisnici);
        }
        //izmeni playlistu
        public void Izmeni(string _ime, string _status, Korisnik autorPlayliste)
        {
            if (!autorPlayliste.SvePlayliste.Contains(this))
            { 
                throw new Exception("Playliste nije pronadjena");
            }
            foreach (Playlista playlista in autorPlayliste.SvePlayliste)
            {
                if (playlista.Id == Id)
                {
                    Ime = _ime;
                    Status = (Status)Enum.Parse(typeof(Status), _status);
                    break;
                }
            }
            Dictionary<string, Korisnik> sviKorisnici = Korisnik.UcitajKorisnike();
            sviKorisnici[autorPlayliste.Id] = autorPlayliste;
            Korisnik.UpisiKorisnike(sviKorisnici);
        }
        //obrisi playlistu
        public void Obrisi(Korisnik autorPlayliste)
        {
            if (!autorPlayliste.SvePlayliste.Contains(this))
            {
                throw new Exception("Playliste nije pronadjena");
            }
            autorPlayliste.SvePlayliste.Remove(this);
            Dictionary<string, Korisnik> sviKorisnici = Korisnik.UcitajKorisnike();
            sviKorisnici[autorPlayliste.Id] = autorPlayliste;
            Korisnik.UpisiKorisnike(sviKorisnici);
        }
        //dodavanje numere na playlistu
        public void DodajNumeru(MuzickaNumera numera)
        {
            if (Numere.ContainsKey(numera.Id))
            { 
                throw new Exception("Numera je vec na playlisti");
            }
            Numere[numera.Id] = numera;
        }
        //uklanjanje numere sa playliste
        public void UkloniNumeru(MuzickaNumera numera)
        {
            if (!Numere.ContainsKey(numera.Id))
            {
                throw new Exception("Numera nije na playlisti");
            }
            Numere.Remove(numera.Id);
        }
    }
}
