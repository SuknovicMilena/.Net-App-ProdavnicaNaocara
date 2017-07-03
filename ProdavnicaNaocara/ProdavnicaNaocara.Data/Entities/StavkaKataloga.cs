using ProdavnicaNaocara.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class StavkaKataloga
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RbStavkeId { get; set; }

        [Required]
        public int ProizvodId { get; set; }

        [Required]
        public int KatalogId { get; set; }

        public string Status { get; set; }

        [ForeignKey("KatalogId")]
        [InverseProperty("Stavke")]
        public Katalog Katalog { get; set; }

        [ForeignKey("ProizvodId")]
        [InverseProperty("Stavka")]
        public Proizvod ProizvodStavke { get; set; }
    }
}
