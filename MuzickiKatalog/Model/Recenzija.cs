using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class Recenzija
    {
        private int id;
        private string opis;
        private int ocena;

        public int Id { get; set; }
        public string Opis { get; set; }
        public int Ocena { get; set; }

    }
}
