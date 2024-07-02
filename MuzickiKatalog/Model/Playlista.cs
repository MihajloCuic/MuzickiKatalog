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
        private Status status;

        public int Id { get; set; }
        public Status Status { get; set; }
    }
}
