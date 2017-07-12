using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class StavkaNarudzbenice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RbStavkeId { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }

        [Required]
        public int NarudzbenicaKupcaId { get; set; }

        [Required]
        public int PonudaId { get; set; }

        [ForeignKey("NarudzbenicaKupcaId")]
        [InverseProperty("Narudzbenice")]
        public Narudzbenica Narudzbenica { get; set; }

        [ForeignKey("PonudaId")]
        [InverseProperty("PonudeZaNar")]
        public Ponuda PonudaZaNar { get; set; }
    }
}
