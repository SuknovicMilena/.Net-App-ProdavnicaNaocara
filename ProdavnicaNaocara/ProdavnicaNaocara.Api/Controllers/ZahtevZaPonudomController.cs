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
    [Route("zahtevi")]
    public class ZahtevZaPonudomController : Controller
    {
        private ZahtevZaPonudomRepository zahtevZaPonudomRepository;
        private KupacRepository kupacRepository;
        private KatalogRepository katalogRepository;

        public ZahtevZaPonudomController(ZahtevZaPonudomRepository zahtevZaPonudomRepository,
            KupacRepository kupacRepository, KatalogRepository katalogRepository)
        {
            this.zahtevZaPonudomRepository = zahtevZaPonudomRepository;
            this.kupacRepository = kupacRepository;
            this.katalogRepository = katalogRepository;
        }

        [HttpGet]
        public IActionResult GetAllZahteviModel()
        {
            var zahtevi = zahtevZaPonudomRepository.GetAllZahtevZaPonudomModel();
            return Ok(zahtevi);
        }


        [HttpPost]
        public IActionResult Add([FromBody]ZahtevZaPonudomModel zahtevModel)
        {
            var katalog = katalogRepository.GetById(zahtevModel.Id);
            if (katalog == null)
            {
                return NotFound("Taj katalog ne postoji, probajte drugi!");
            }

            var kupac = kupacRepository.GetById(zahtevModel.Id);
            if (kupac == null)
            {
                return NotFound("Taj kupac ne postoji, probajte drugi!");

            }
            var zahtev = new ZahtevZaPonudom
            {
                Datum = zahtevModel.Datum,
                KatalogId = zahtevModel.KatalogId,
                KupacId = zahtevModel.KupacId

            };
            zahtevZaPonudomRepository.Insert(zahtev);
            zahtevZaPonudomRepository.Save();

            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody]ZahtevZaPonudomModel zahtevModel)
        {
            var zahtev = zahtevZaPonudomRepository.GetById(Id);
            if (zahtev == null)
            {
                return NotFound("Taj zahtev ne postoji!");
            }
            zahtev.Datum = zahtevModel.Datum;
            zahtev.KatalogId = zahtevModel.KatalogId;
            zahtev.KupacId = zahtevModel.KupacId;

            zahtevZaPonudomRepository.Save();

            return new NoContentResult();

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var zahtev = zahtevZaPonudomRepository.GetById(Id);
            if (zahtev == null)
            {
                return NotFound("Taj zahtev ne postoji!");
            }
            zahtevZaPonudomRepository.Delete(zahtev);
            zahtevZaPonudomRepository.Save();


            return new NoContentResult();

        }

    }
}