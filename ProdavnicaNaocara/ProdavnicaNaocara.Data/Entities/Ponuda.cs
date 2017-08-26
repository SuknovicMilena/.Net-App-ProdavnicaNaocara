using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Ponuda
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public String Napomena { get; set; }

        [Required]
        public int ZahtevId { get; set; }

        [ForeignKey("ZahtevId")]
        [InverseProperty("PonudaKupcu")]
        public ZahtevZaPonudom ZahtevZaPonudom { get; set; }


        [InverseProperty("Ponuda")]
        public List<Narudzbenica> Ponude { get; set; }

        [InverseProperty("PonudaStavki")]
        public List<StavkaPonude> StavkePonude { get; set; }

        [InverseProperty("PonudaZaNar")]
        public List<StavkaNarudzbenice> PonudeZaNar { get; set; }

    }
}
