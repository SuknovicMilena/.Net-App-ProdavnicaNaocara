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
        private ZahtevZaPonudomRepository zahtevZaPonudomRepository;


        public KupacController(KupacRepository kupacRepository, AdresaRepository adresaRepository, UlicaRepostitory ulicaRepostitory, MestoRepository mestoRepository, ZahtevZaPonudomRepository zahtevZaPonudomRepository)
        {
            this.kupacRepository = kupacRepository;
            this.adresaRepository = adresaRepository;
            this.mestoRepository = mestoRepository;
            this.ulicaRepostitory = ulicaRepostitory;
            this.zahtevZaPonudomRepository = zahtevZaPonudomRepository;
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
        [HttpGet("zahtevi/{kupacId}")]
        public IActionResult GetZahteviZaKupca(int kupacId)
        {
            var zahtevi = zahtevZaPonudomRepository.GetAllZahteviZaKupca(kupacId);
            return Ok(zahtevi);
        }
        [HttpGet("zahtev/{id}")]
        public IActionResult GetZahtevById(int id)
        {
            var zahtev = zahtevZaPonudomRepository.GetAllZahtevById(id);
            return Ok(zahtev);
        }
        [HttpPost]
        public IActionResult Add([FromBody]KupacModel kupacModel)
        {
            var adresaZaBazu = new Adresa
            {
                UlicaId = kupacModel.UlicaId,
                Broj = kupacModel.Broj
            };
            adresaRepository.Insert(adresaZaBazu);
            adresaRepository.Save();

            var kupac = new Kupac
            {
                Naziv = kupacModel.Naziv,
                BrojTelefona = kupacModel.BrojTelefona,
                AdresaId = adresaZaBazu.Id
            };
            kupacRepository.Insert(kupac);
            kupacRepository.Save();
            return Ok(kupac);
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