using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class StavkaReklamacije
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RbStavkeId { get; set; }
        public string Opis { get; set; }

        [Required]
        public int ReklamacijaId { get; set; }

        [Required]
        public int ProizvodId { get; set; }

        [ForeignKey("ReklamacijaId")]
        [InverseProperty("StavkeReklamacije")]
        public Reklamacija Reklamacija { get; set; }

        [ForeignKey("ProizvodId")]
        [InverseProperty("StavkeReklamacije")]
        public Proizvod ProizvodZaReklamaciju { get; set; }

    }
}
