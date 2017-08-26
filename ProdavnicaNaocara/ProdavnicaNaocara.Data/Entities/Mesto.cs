using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Mesto
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        [InverseProperty("Mesto")]
        public List<Ulica> Ulice { get; set; } = new List<Ulica>();






    }
}
