using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MuzickiKatalog.Model
{
    internal class test
    {
        public static void testiranje()
        {
            //KorisnickiNalog korisnik = new KorisnickiNalog("user1", "password", VrstaKorisnika.korisnik);
            //KorisnickiNalog admin = new KorisnickiNalog("user2", "password", VrstaKorisnika.administrator);
            //KorisnickiNalog mUrednik = new KorisnickiNalog("user3", "password", VrstaKorisnika.muzickiUrednik);
            //Dictionary<string, KorisnickiNalog> korisnickiNalozi = new Dictionary<string, KorisnickiNalog>();
            //korisnik.Dodaj();
            //admin.Dodaj();
            //admin.Obrisi();
            //korisnik.Izmeni("password5");
            //korisnik.Obrisi();
            //korisnickiNalozi.Add("user1", korisnik);
            //korisnickiNalozi.Add("user2", admin);
            //korisnickiNalozi.Add("user3", mUrednik);
            //KorisnickiNalog.UpisiKorisnickeNaloge(korisnickiNalozi);
            KorisnickiNalog.Login("user1", "password5");
        }
       

    }
}
