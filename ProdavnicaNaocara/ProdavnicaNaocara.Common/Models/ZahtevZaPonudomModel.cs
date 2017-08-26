using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaNaocara.Common.Models
{
    public class ZahtevZaPonudomModel
    {
        public int Id { get; set; }
        public string KatalogNaziv { get; set; }
        public DateTime Datum { get; set; }
        public int KatalogId { get; set; }
        public int KupacId { get; set; }
        public string KupacNaziv { get; set; }
    }
}
