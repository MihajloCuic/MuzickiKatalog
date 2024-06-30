using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public abstract class Osoba
    {
        private string ime;
        private string prezime;
        private string email;
        private string telefon;
        private string id;
        private List<Recenzija> sveRecenzije;

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Id { get; set; }
        public List<Recenzija> SveRecenzije { get; set; }

    }
}
