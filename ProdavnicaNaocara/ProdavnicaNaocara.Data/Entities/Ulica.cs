using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Ulica
    {
        public int Id { get; set; }

        [Required]
        public int MestoId { get; set; }

        [ForeignKey("MestoId")]
        [InverseProperty("Ulice")]
        public Mesto Mesto { get; set; }

        [InverseProperty("Ulica")]
        public List<Adresa> Adrese { get; set; } = new List<Adresa>();
    }
}
