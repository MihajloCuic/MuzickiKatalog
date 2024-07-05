using MuzickiKatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Controller
{
    public class RegistracijaControler
    {
        public static Korisnik Registracija(string ime, string prezime, string email, string telefon, string lozinka) 
        {
            if (string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(lozinka))
            {
                throw new Exception("Polja ne smeju biti ostavljena prazna!");
            }

            Korisnik korisnik = KorisnickiNalog.Register(ime, prezime, email, telefon, lozinka);
            korisnik.Dodaj();
            return korisnik;
        }
    }
}
