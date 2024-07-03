using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    internal class MFunctionsES
    {
        public static void test1()
        {
            List<Zanr> zanrovi = new List<Zanr>
            {
                new Zanr { Id = 1, Naziv = "Rock" },
                new Zanr { Id = 2, Naziv = "Pop" }
            };
             List<Recenzija> recenzije = new List<Recenzija>
            {
                new Recenzija { Id = 1, Opis = "Odlična pesma!", Ocena = 5 },
                new Recenzija { Id = 2, Opis = "Dobra melodija.", Ocena = 4 }
            };
            List<ElementSistema> izvodjaci = new List<ElementSistema>
            {
                new Izvodjac()
            };

            MuzickaGrupa muzickaGrupa = new MuzickaGrupa(
                _ime: "Grupa 1",
                _prosecnaOcena: 5,
                _opis: "Popularna muzička grupa",
                _id: 1,
                _sviZanrovi: zanrovi,
                _sveRecenzije: recenzije,
                _izvodjaci: new List<Izvodjac>(),
                _numere: new List<MuzickaNumera>()
            );
            Izvodjac izvodjac = new Izvodjac(
                _ime: "Izvodjac 1",
                _prosecnaOcena: 5,
                _opis: "Poznati izvođač",
                _id: 2,
                _muzickaGrupa: muzickaGrupa,
                _sviZanrovi: zanrovi,
                _sveRecenzije: recenzije,
                _numere: new List<MuzickaNumera>()
            );

            // Kreiranje instance MuzickaNumera
            MuzickaNumera muzickaNumera = new MuzickaNumera(
                _ime: "Pesma 1",
                _prosecnaOcena: 5,
                _opis: "Prva pesma",
                _id: 3,
                _datumIzbacivanja: DateTime.Now,
                _sviZanrovi: zanrovi,
                _sveRecenzije: recenzije,
                _izvodjaci: new List<Izvodjac> { izvodjac }
            );
            Koncert koncert = new Koncert(
                _ime: "Koncert 1",
                _prosecnaOcena: 5,
                _opis: "Veliki koncert",
                _id: 4,
                _snimatelj: "Snimatelj 1",
                _formatPrikaza: "HD",
                _datumDesavanja: DateTime.Now.AddDays(-30),
                _sviZanrovi: zanrovi,
                _sveRecenzije: recenzije,
                _elementiKoncerta: new List<ElementSistema> { izvodjac , muzickaNumera}
            );

            // Kreiranje instance Album
            Album album = new Album(
                _ime: "Album 1",
                _prosecnaOcena: 5,
                _opis: "Debi album",
                _id: 5,
                _datumIzdavanja: DateTime.Now.AddYears(-1),
                _sviZanrovi: zanrovi,
                _sveRecenzije: recenzije,
                _numereAlbuma: new List<MuzickaNumera> { muzickaNumera },
                _izvodjaci: new List<Izvodjac> { izvodjac }
            );
            // Dodavanje instance izvodjaca u muzicku grupu
            muzickaGrupa.Izvodjaci.Add(izvodjac);

            // Dodavanje numere u izvodjaca
            izvodjac.Numere.Add(muzickaNumera);

            // Dodavanje izvodjaca u numeru
            muzickaNumera.Izvodjaci.Add(izvodjac);
            //TESTIRANJE CRUDA
            muzickaGrupa.Dodaj();
            muzickaGrupa.Izmeni(_ime: "Grupa Test Izmenjena",
                _prosecnaOcena: 4,
                _opis: "Izmenjeni opis testne muzičke grupe",
                _sviZanrovi: zanrovi,
                _sveRecenzije: recenzije,
                _izvodjaci: new List<Izvodjac>(),
                _numere: new List<MuzickaNumera>()
            );
            muzickaGrupa.Obrisi();

            izvodjac.Dodaj();
            izvodjac.Izmeni(_ime: "Izvodjac 1",
                _prosecnaOcena: 5,
                _opis: "Poznati izvođač nad izvodjacima",
                _muzickaGrupa: muzickaGrupa,
                _sviZanrovi: zanrovi,
                _sveRecenzije: recenzije,
                _numere: new List<MuzickaNumera>());
            izvodjac.Obrisi();

            muzickaNumera.Dodaj();
            muzickaNumera.Izmeni(_ime: "Pesma 1",
                _prosecnaOcena: 5,
                _opis: "Prva pesma je konza",
                _datumIzbacivanja: DateTime.Now,
                _sviZanrovi: zanrovi,
                _sveRecenzije: recenzije,
                _izvodjaci: new List<Izvodjac> { izvodjac });
            muzickaNumera.Obrisi();

            album.Dodaj();
            album.Izmeni(_ime: "Album 1",
                _prosecnaOcena: 5,
                _opis: "Debi album je konza",
                _datumIzdavanja: DateTime.Now.AddYears(-1),
                _sviZanrovi: zanrovi,
                _sveRecenzije: recenzije,
                _numereAlbuma: new List<MuzickaNumera> { muzickaNumera },
                _izvodjaci: new List<Izvodjac> { izvodjac });
            album.Obrisi();

            koncert.Dodaj();
            koncert.Izmeni(_ime: "Koncert 1",
                _prosecnaOcena: 5,
                _opis: "Veliki koncert je konza",
                _snimatelj: "Snimatelj 1",
                _formatPrikaza: "HD",
                _datumDesavanja: DateTime.Now.AddDays(-30),
                _sviZanrovi: zanrovi,
                _sveRecenzije: recenzije,
                _elementiKoncerta: new List<ElementSistema> { izvodjac,muzickaNumera });
            koncert.Obrisi();

            
        }
    }
}
