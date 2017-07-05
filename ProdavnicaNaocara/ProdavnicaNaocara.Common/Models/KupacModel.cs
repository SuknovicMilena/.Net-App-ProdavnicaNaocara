using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaNaocara.Common.Models
{
    public class KupacModel
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string BrojTelefona { get; set; }

        public int AdresaId { get; set; }

        public string AdresaNaziv { get; set; }


    }
}
