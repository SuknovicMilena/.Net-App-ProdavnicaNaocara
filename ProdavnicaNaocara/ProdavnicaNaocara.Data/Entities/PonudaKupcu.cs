using ProdavnicaNaocara.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class PonudaKupcu
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }

        public String Napomena { get; set; }

        [Required]
        public int ZahtevId { get; set; }

        [ForeignKey("ZahtevId")]
        [InverseProperty("PonudaKupcu")]
        public ZahtevZaPonudom ZahtevZaPonudom { get; set; }
    }
}
