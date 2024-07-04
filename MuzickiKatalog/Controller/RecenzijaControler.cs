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
        public static void DodajRecenziju(string opis, int ocena, string recezent, int recenziraniElement)
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
        }
    }
}
