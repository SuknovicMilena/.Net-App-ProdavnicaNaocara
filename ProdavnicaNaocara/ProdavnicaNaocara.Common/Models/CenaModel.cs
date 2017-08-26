using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaNaocara.Common.Models
{
    public class CenaModel
    {
        public int Id { get; set; }
        public int ProizvodId { get; set; }
        public String ProizvodIme { get; set; }
        public double IznosCene { get; set; }
        public int IznosPopusta { get; set; }
    }
}
