using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Reklamacija
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public String Napomena { get; set; }

        [Required]
        public int FakturaId { get; set; }

        [ForeignKey("FakturaId")]
        [InverseProperty("Reklamacije")]
        public Faktura Faktura { get; set; }

        [InverseProperty("Reklamacija")]
        public List<StavkaReklamacije> StavkeReklamacije { get; set; }
    }
}
