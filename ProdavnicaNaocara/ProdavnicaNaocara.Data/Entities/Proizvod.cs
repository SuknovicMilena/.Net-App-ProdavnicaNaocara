using ProdavnicaNaocara.Common.Enums;
using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Proizvod
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        [MinLength(3, ErrorMessage = "Ime mora da bude najmanje 3 karaktera dugo")]
        public string Ime { get; set; }

        [Required]
        public int ProizvodjacId { get; set; }

        public TipProizvoda Tip { get; set; }

        [ForeignKey("ProizvodjacId")]
        [InverseProperty("Proizvodi")]
        public Proizvodjac Proizvodjac { get; set; }

        [InverseProperty("Proizvod")]
        public List<Cena> Cene { get; set; }

        [InverseProperty("ProizvodStavke")]
        public StavkaKataloga Stavka { get; set; }

        [InverseProperty("ProizvodPonuda")]
        public List<StavkaPonude> ProizvodiPonuda { get; set; }

        [InverseProperty("ProizvodFakt")]
        public List<StavkaFakture> ProizvodiUFakt { get; set; }

        [InverseProperty("ProizvodZaReklamaciju")]
        public List<StavkaReklamacije> StavkeReklamacije { get; set; }

        [InverseProperty("ProizvodOtpremnica")]
        public List<StavkaOtpremnice> StavkeOtpremnice { get; set; }
    }
}
