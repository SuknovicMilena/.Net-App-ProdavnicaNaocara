using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Narudzbenica
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Datum { get; set; }

        [Required]
        public int KupacId { get; set; }

        [Required]
        public int PonudaId { get; set; }

        [ForeignKey("KupacId")]
        [InverseProperty("KupciNarudzbenica")]
        public Kupac KupacNarudzbenica { get; set; }

        [ForeignKey("PonudaId")]
        [InverseProperty("Ponude")]
        public Ponuda Ponuda { get; set; }

        [InverseProperty("NarudzbenicaKupca")]
        public List<Otpremnica> OtpremniceNaOsnovuNarudzbenice { get; set; }

        [InverseProperty("Narudzbenica")]
        public List<StavkaNarudzbenice> Narudzbenice { get; set; }


    }
}
