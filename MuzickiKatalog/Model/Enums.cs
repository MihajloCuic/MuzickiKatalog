using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public enum VrstaKorisnika {
        korisnik,
        muzickiUrednik,
        administrator
    }

    public enum Status { 
        privateList,
        publicList
    }
}
