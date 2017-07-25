using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProdavnicaNaocara.Data.Repositories;
using ProdavnicaNaocara.Data.Entities;

namespace ProdavnicaNaocara.Api.Controllers
{
    [Route("stavkePonude")]
    public class StavkaPonudeController : Controller
    {
        private StavkaPonudeRepository stavkaPonudeRepositry;
        private ProizvodiRepository proizvodiRepository;

        public StavkaPonudeController(StavkaPonudeRepository stavkaPonudeRepositry, ProizvodiRepository proizvodiRepository)
        {
            this.stavkaPonudeRepositry = stavkaPonudeRepositry;
            this.proizvodiRepository = proizvodiRepository;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stavke = stavkaPonudeRepositry.GetAllByStavkaPonudeModel();
            return Ok(stavke);
        }
        [HttpGet("{rb}")]
        public IActionResult GetById(int rb)
        {
            var stavka = stavkaPonudeRepositry.GetStavkaById(rb);
            return Ok(stavka);
        }

        [HttpPost]
        public IActionResult Add([FromBody]StavkaPonude model)
        {
            var proizvod = proizvodiRepository.GetById(model.ProizvodId);
            if (proizvod == null)
            {
                return NotFound("Ne postoji taj proizvod");

            }

            var stavka = new StavkaPonude
            {
                PonudaId = model.PonudaId,
                ProizvodId = model.ProizvodId,
                Kolicnina = model.Kolicnina,
                StatusPonude = model.StatusPonude

            };

            stavkaPonudeRepositry.Insert(stavka);
            stavkaPonudeRepositry.Save();

            return Ok();

        }
        [HttpPut("{rb}/ponuda/{ponudaId}")]
        public IActionResult Update(int rb, int ponudaId, [FromBody]StavkaPonude model)
        {
            var stavka = stavkaPonudeRepositry.GetById(rb, ponudaId);
            if (stavka == null)
            {
                return NotFound("Stavka sa datim rednim brojem ne postoji");
            }

            var proizvod = proizvodiRepository.GetById(model.ProizvodId);
            if (proizvod == null)
            {
                return NotFound("Ne postoji taj proizvod");

            }

            stavka.StatusPonude = model.StatusPonude;
            stavka.ProizvodId = model.ProizvodId;
            stavka.Kolicnina = model.Kolicnina;

            stavkaPonudeRepositry.Save();

            return new NoContentResult();

        }
        [HttpDelete("{rb}/ponuda/{ponudaId}")]
        public IActionResult Delete(int rb, int ponudaId)
        {
            var stavka = stavkaPonudeRepositry.GetById(rb, ponudaId);
            if (stavka == null)
            {
                return NotFound("Stavka sa datim rednim brojem ne postoji");
            }

            stavkaPonudeRepositry.Delete(stavka);
            stavkaPonudeRepositry.Save();

            return new NoContentResult();

        }

    }
}