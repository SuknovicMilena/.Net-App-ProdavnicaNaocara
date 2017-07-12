using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Proizvodjac
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        [MinLength(3, ErrorMessage = "Ime mora da bude najmanje 3 karaktera dugo")]
        public string Ime { get; set; }

        public string Adresa { get; set; }

        [InverseProperty("Proizvodjac")]
        public List<Proizvod> Proizvodi { get; set; }
    }
}
