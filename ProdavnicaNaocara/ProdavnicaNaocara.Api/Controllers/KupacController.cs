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
    [Route("kupci")]
    public class KupacController : Controller
    {

        private KupacRepository kupacRepository;
        private AdresaRepository adresaRepository;
        private UlicaRepostitory ulicaRepostitory;
        private MestoRepository mestoRepository;


        public KupacController(KupacRepository kupacRepository, AdresaRepository adresaRepository, UlicaRepostitory ulicaRepostitory, MestoRepository mestoRepository)
        {
            this.kupacRepository = kupacRepository;
            this.adresaRepository = adresaRepository;
            this.mestoRepository = mestoRepository;
            this.ulicaRepostitory = ulicaRepostitory;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var kupci = kupacRepository.GetAllKupacModel();
            return Ok(kupci);
        }
        [HttpGet("{Id}")]
        public IActionResult GetAll(int Id)
        {
            var kupci = kupacRepository.GetKupacModelById(Id);
            return Ok(kupci);
        }
        [HttpPost]
        public IActionResult Add([FromBody]KupacModel kupacModel)
        {

            var adresa = adresaRepository.GetById(kupacModel.Id);
            if (adresa == null)
            {
                return NotFound("ne postoji ta adresa, probajte drugu");
            }

            var kupac = new Kupac
            {
                Naziv = kupacModel.Naziv,
                BrojTelefona = kupacModel.BrojTelefona,
                AdresaId = kupacModel.AdresaId


            };
            kupacRepository.Insert(kupac);
            kupacRepository.Save();
            return Ok();

        }
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody]KupacModel model)
        {
            var kupac = kupacRepository.GetById(Id);

            if (kupac == null)
            {
                return NotFound("Taj kupac ne postoji");
            }
            kupac.Naziv = model.Naziv;
            kupac.BrojTelefona = model.BrojTelefona;
            kupac.AdresaId = model.AdresaId;
            kupacRepository.Save();
            return new NoContentResult();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var kupac = kupacRepository.GetById(Id);
            if (kupac == null)
            {
                return NotFound("Taj kupac ne postoji");
            }
            kupacRepository.Delete(kupac);
            kupacRepository.Save();
            return new NoContentResult();
        }

    }
}