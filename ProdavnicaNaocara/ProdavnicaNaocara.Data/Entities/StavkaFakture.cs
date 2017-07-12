using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class StavkaFakture
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RbStavkeId { get; set; }
        public int FakturaId { get; set; }
        public double Cena { get; set; }
        public int Kolicina { get; set; }

        [Required]
        public int ProizvodId { get; set; }

        [ForeignKey("ProizvodId")]
        [InverseProperty("ProizvodiUFakt")]
        public Proizvod ProizvodFakt { get; set; }

    }
}
