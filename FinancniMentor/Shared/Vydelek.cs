using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancniMentor.Shared
{
    public class Vydelek
    {
        public Vydelek()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime Datum { get; set; }
        public string Subjekt { get; set; }
        public VydelekKategorie Kategorie { get; set; }
        public decimal Castka { get; set; }
    }
}
