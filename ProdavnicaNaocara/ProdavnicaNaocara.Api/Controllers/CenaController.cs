using Microsoft.AspNetCore.Mvc;
using ProdavnicaNaocara.Common.Models;
using ProdavnicaNaocara.Data.Entities;
using ProdavnicaNaocara.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdavnicaNaocara.Api.Controllers
{
    [Route("cene")]
    public class CenaController : BaseController
    {
        private CenaRepository cenaRepository;
        private ProizvodiRepository proizvodiRepository;

        public CenaController(CenaRepository cenaRepository, ProizvodiRepository proizvodiRepository)
        {
            this.cenaRepository = cenaRepository;
            this.proizvodiRepository = proizvodiRepository;
        }



        [HttpGet("model")]
        public IActionResult GetByModel()
        {
            var cena = cenaRepository.GetAllCenaModels();



            return Ok(cena);
        }
        public IActionResult GetAll()
        {
            var cena = cenaRepository.GetAll();
            return Ok(cena);
        }
        [HttpPost]
        public IActionResult Add([FromBody]CenaModel model)
        {
            var proizvodIzBaze = proizvodiRepository.GetById(model.ProizvodId);

            if (proizvodIzBaze == null)
            {
                return NotFound($"Proizvod sa id-em {model.ProizvodId} ne postoji!");
            }

            var cenaZaBazu = new Cena
            {
                Id = model.Id,
                ProizvodId = model.ProizvodId,
                IznosCene = model.IznosCene,
                IznosPopusta = model.IznosPopusta



            };

            cenaRepository.Insert(cenaZaBazu);
            cenaRepository.Save();

            //var result = proizvodiRepository.GetProizvodModelById(proizvodZaBazu.Id);

            //return CreatedAtRoute("GetProizvod", new { id = proizvodZaBazu.Id }, result);
            return Ok();
        }

        [HttpPut("{Cenaid}/{ProizvodId}")]
        public IActionResult Update(int Cenaid, int ProizvodId, [FromBody]CenaModel model)
        {
            var cenaIzBaze = cenaRepository.GetById(Cenaid, ProizvodId);

            if (cenaIzBaze == null)
            {

                return NotFound($"Crna sa id-em {cenaIzBaze} ne postoji!");
            }



            cenaIzBaze.IznosCene = model.IznosCene;
            cenaIzBaze.IznosPopusta = model.IznosPopusta;



            cenaRepository.Save();

            return new NoContentResult();
        }



        [HttpDelete("{Cenaid}/{ProizvodId}")]
        public IActionResult Delete(int Cenaid, int ProizvodId)
        {
            var cenaIzBaze = cenaRepository.GetById(Cenaid, ProizvodId);


            if (cenaIzBaze == null)
            {
                return NotFound($"Cena sa id-em {cenaIzBaze} ne postoji.");
            }

            cenaRepository.Delete(cenaIzBaze);
            cenaRepository.Save();

            return new NoContentResult();
        }


    }


}
