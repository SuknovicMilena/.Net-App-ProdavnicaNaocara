using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class Zaposleni
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        [InverseProperty("Zaposlen")]
        public List<Otpremnica> OtpremnicaZaposleni { get; set; } = new List<Otpremnica>();
    }
}
