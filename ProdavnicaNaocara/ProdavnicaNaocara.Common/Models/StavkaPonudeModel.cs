using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaNaocara.Common.Models
{
    public class StavkaPonudeModel
    {

        public int RbStavkeId { get; set; }
        public int PonudaId { get; set; }
        public int ProizvodId { get; set; }
        public string ProizvodNaziv { get; set; }
        public int Kolicnina { get; set; }
        public int StatusPonude { get; set; }


    }
}
