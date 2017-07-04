using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Adresa
    {
        public int Id { get; set; }
        public int Broj { get; set; }

        [Required]
        public int UlicaId { get; set; }

        [ForeignKey("UlicaId")]
        [InverseProperty("Adrese")]
        public Ulica Ulica { get; set; }

        [InverseProperty("Adresa")]
        public List<Kupac> Kupci { get; set; }
    }
}
