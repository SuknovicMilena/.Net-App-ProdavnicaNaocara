using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Cena
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double IznosCene { get; set; }
        public int IznosPopusta { get; set; }

        [Required]
        public int ProizvodId { get; set; }


        [ForeignKey("ProizvodId")]
        [InverseProperty("Cene")]
        public Proizvod Proizvod { get; set; }
    }

}
