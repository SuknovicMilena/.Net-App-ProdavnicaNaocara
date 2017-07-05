using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Kupac
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string BrojTelefona { get; set; }

        [Required]
        public int AdresaId { get; set; }

        [ForeignKey("AdresaId")]
        [InverseProperty("Kupci")]
        public Adresa Adresa { get; set; }

        [InverseProperty("Kupac")]
        public List<ZahtevZaPonudom> ZahteviZaPonudom { get; set; }





    }
}
