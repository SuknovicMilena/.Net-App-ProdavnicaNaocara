using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Katalog
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        [InverseProperty("Katalog")]
        public List<StavkaKataloga> Stavke { get; set; }

        [InverseProperty("Katalog")]
        public List<ZahtevZaPonudom> ZahteviZaPonudom { get; set; }
    }
}
