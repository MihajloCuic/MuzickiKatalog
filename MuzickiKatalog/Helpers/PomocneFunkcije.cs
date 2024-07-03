using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Helpers
{
    public class PomocneFunkcije
    {
        public static int NapraviIDGlasanja(DateTime datumPocetka, DateTime datumZavrsetka, string imeTakmicenja)
        { 
            TimeSpan razlika = datumZavrsetka - datumPocetka;
            int brojDana = (int)razlika.TotalHours;
            int hashImenaTakmicenja = imeTakmicenja.GetHashCode();
            return hashImenaTakmicenja ^ brojDana;
        }
    }
}
