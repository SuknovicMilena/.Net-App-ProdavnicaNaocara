using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Otpremnica
    {
        public int Id { get; set; }

        public DateTime DatumOtpreme { get; set; }

        [Required]
        public int ZaposleniId { get; set; }

        [Required]
        public int NarudzbenicaKupcaId { get; set; }

        [Required]
        public int KupacId { get; set; }

        [ForeignKey("ZaposleniId")]
        [InverseProperty("OtpremnicaZaposleni")]
        public Zaposleni Zaposlen { get; set; }

        [ForeignKey("NarudzbenicaKupcaId")]
        [InverseProperty("OtpremniceNaOsnovuNarudzbenice")]
        public Narudzbenica NarudzbenicaKupca { get; set; }

        [ForeignKey("KupacId")]
        [InverseProperty("KupaciZaOtpremu")]
        public Kupac KupacOtprema { get; set; }

        [InverseProperty("Otpremnica")]
        public List<Faktura> Otpremnice { get; set; }

        [InverseProperty("OtpremnicaS")]
        public List<StavkaOtpremnice> StavkeOtpremnice { get; set; }

    }
}
