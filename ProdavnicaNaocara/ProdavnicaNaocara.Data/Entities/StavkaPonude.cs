using ProdavnicaNaocara.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class StavkaPonude
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RbStavkeId { get; set; }

        [Required]
        public int PonudaId { get; set; }

        [Required]
        public int ProizvodId { get; set; }


        public int Kolicnina { get; set; }

        public string StatusPonude { get; set; }

        [ForeignKey("PonudaId")]
        [InverseProperty("StavkePonude")]
        public Ponuda PonudaStavki { get; set; }

        [ForeignKey("ProizvodId")]
        [InverseProperty("ProizvodiPonuda")]
        public Proizvod ProizvodPonuda { get; set; }


    }
}
