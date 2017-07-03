using ProdavnicaNaocara.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdavnicaNaocara.Common.Models
{
    public class ProizvodModel
    {
        public int Id { get; set; }

        public string Ime { get; set; }

        public TipProizvoda Tip { get; set; }

        public int ProizvodjacId { get; set; }

        public string ProizvodjacIme { get; set; }

        
    }
}
