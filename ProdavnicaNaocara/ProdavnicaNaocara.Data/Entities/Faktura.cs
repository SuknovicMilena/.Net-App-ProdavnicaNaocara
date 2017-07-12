using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Faktura
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        [Required]
        public int OtpremnicaId { get; set; }

        [ForeignKey("OtpremnicaId")]
        [InverseProperty("Otpremnice")]
        public Otpremnica Otpremnica { get; set; }

        [InverseProperty("Faktura")]
        public List<Reklamacija> Reklamacije { get; set; }
    }
}
