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
    [Route("adrese")]
    public class AdresaController : BaseController
    {
        private UlicaRepostitory ulicaRepository;
        private AdresaRepository adresaRepository;
        public AdresaController(UlicaRepostitory ulicaRepository, AdresaRepository adresaRepository)
        {
            this.ulicaRepository = ulicaRepository;
            this.adresaRepository = adresaRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var adrese = adresaRepository.getAllAdresaModel();
            return Ok(adrese);
        }
        [HttpPost]
        public IActionResult Add([FromBody]AdresaModel model)
        {
            var ulica = ulicaRepository.GetById(model.UlicaId);
            if (ulica == null)
            {
                return NotFound("Trazena ulica ne postoji");
            }
            var adresa = new Adresa
            {

                Broj = model.Broj,
                UlicaId = model.UlicaId
            };
            adresaRepository.Insert(adresa);
            adresaRepository.Save();
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody]AdresaModel model)
        {

            var adresa = adresaRepository.GetById(Id);
            if (adresa == null)
            {
                return NotFound("Trazena adresa ne postoji");
            }
            var ulicaId = ulicaRepository.GetById(model.UlicaId);
            if (ulicaId == null)
            {
                return NotFound("Trazena ulica ne postoji");
            }

            adresa.Broj = model.Broj;
            adresa.UlicaId = ulicaId.Id;

            adresaRepository.Save();
            return new NoContentResult();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var adresa = adresaRepository.GetById(Id);
            if (adresa == null)
            {
                return NotFound("Trazena adresa ne postoji.");
            }
            adresaRepository.Delete(adresa);
            adresaRepository.Save();
            return new NoContentResult();
        }


    }
}