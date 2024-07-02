using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Helpers
{
    public class Helpers
    {
        //pravi id tipa int kao kombinaciju id-jeva osobe i elementa sistema
        public int NapraviID(string idOsobe, int idElementaSistema)
        { 
            int hashMail = idOsobe.GetHashCode();
            int noviId = hashMail ^ idElementaSistema;
            return noviId;
        }
    }
}
