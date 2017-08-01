using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaNaocara.Common.Models
{
    public class PonudaModel
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public String Napomena { get; set; }
        public int ZahtevId { get; set; }
        public string ZahtevNaziv { get; set; }
    }
}
