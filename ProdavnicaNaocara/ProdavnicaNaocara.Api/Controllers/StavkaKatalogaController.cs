using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProdavnicaNaocara.Data.Repositories;
using ProdavnicaNaocara.Common.Models;
using ProdavnicaNaocara.Data.Entities;

namespace ProdavnicaNaocara.Api.Controllers
{
    [Route("stavkeKataloga")]

    public class StavkaKatalogaController : Controller
    {
        private StavkaKatalogaRepository stavkaKatalogaRepository;
        private ProizvodiRepository proizvodiRepository;

        public StavkaKatalogaController(StavkaKatalogaRepository stavkaKatalogaRepository, ProizvodiRepository proizvodiRepository)
        {
            this.stavkaKatalogaRepository = stavkaKatalogaRepository;
            this.proizvodiRepository = proizvodiRepository;

        }


        [HttpGet]
        public IActionResult GetAllByModel()
        {
            var stavke = stavkaKatalogaRepository.GetAllStavkaKatalogaModel();

            return Ok(stavke);
        }
        [HttpPost]
        public IActionResult Add([FromBody]StavkaKatalogaModel model)
        {
            var proizvod = proizvodiRepository.GetById(model.ProizvodId);
            if (proizvod == null)
            {
                return NotFound("Ne postoji taj proizvod koji hocete da dodate");
            }
            var stavka = new StavkaKataloga
            {
                RbStavkeId = model.RBStavke,
                KatalogId = model.KatalogId,
                ProizvodId = model.ProizvodId,
                Status = model.Status

            };
            stavkaKatalogaRepository.Insert(stavka);
            stavkaKatalogaRepository.Save();
            return Ok();
        }
        [HttpPut("{RbStavke}/{KatalogId}")]
        public IActionResult Update(int RbStavke, int KatalogId, [FromBody]StavkaKatalogaModel model)
        {
            var stavkaIzBaze = stavkaKatalogaRepository.GetById(RbStavke, KatalogId);
            if (stavkaIzBaze == null)
            {
                return NotFound("Ne postoji u bazi ta stavka");
            }

            stavkaIzBaze.ProizvodId = model.ProizvodId;
            stavkaIzBaze.Status = model.Status;
            stavkaKatalogaRepository.Save();

            return new NoContentResult();
        }
        [HttpDelete("{RbStavke}/{KatalogId}")]
        public IActionResult Delete(int RbStavke, int KatalogId)
        {
            var stavkaIzBaze = stavkaKatalogaRepository.GetById(RbStavke, KatalogId);
            if (stavkaIzBaze == null)
            {
                return NotFound("Ne postoji u bazi ta stavka");
            }
            stavkaKatalogaRepository.Delete(stavkaIzBaze);
            stavkaKatalogaRepository.Save();

            return new NoContentResult();
        }

    }
}