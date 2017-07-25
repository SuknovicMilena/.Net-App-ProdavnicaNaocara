using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class ZahtevZaPonudom
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }

        [Required]
        public int KatalogId { get; set; }

        [Required]
        public int KupacId { get; set; }


        [ForeignKey("KatalogId")]
        [InverseProperty("ZahteviZaPonudom")]
        public Katalog Katalog { get; set; }

        [ForeignKey("KupacId")]
        [InverseProperty("ZahteviZaPonudom")]
        public Kupac Kupac { get; set; }





    }
}
