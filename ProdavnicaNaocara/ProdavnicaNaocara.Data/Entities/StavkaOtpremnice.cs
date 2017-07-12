using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdavnicaNaocara.Data.Entities
{
    public class StavkaOtpremnice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RbStavkeId { get; set; }

        public int Kolicina { get; set; }


        [Required]
        public int OtpremnicaId { get; set; }

        [Required]
        public int ProizvodId { get; set; }

        [ForeignKey("OtpremnicaId")]
        [InverseProperty("StavkeOtpremnice")]
        public Otpremnica OtpremnicaS { get; set; }


    }
}
