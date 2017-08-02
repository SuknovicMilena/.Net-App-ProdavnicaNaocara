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
    [Route("ponude")]
    public class PonudaController : Controller
    {
        private PonudaRepository ponudaRepository;
        private ZahtevZaPonudomRepository zahtevZaPonudomRepository;

        public PonudaController(PonudaRepository ponudaRepository, ZahtevZaPonudomRepository zahtevZaPonudomRepository)
        {
            this.ponudaRepository = ponudaRepository;
            this.zahtevZaPonudomRepository = zahtevZaPonudomRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ponude = ponudaRepository.GetAllPonudaModel();
            return Ok(ponude);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ponuda = ponudaRepository.GetAllPonudaModelById(id);
            return Ok(ponuda);
        }

        [HttpGet("zahtevi")]
        public IActionResult GetAllZahtevi()
        {
            var zahtevi = zahtevZaPonudomRepository.GetAllZahtevZaPonudomModel();
            return Ok(zahtevi);
        }

        [HttpPost]
        public IActionResult Add([FromBody]PonudaModel model)
        {
            var zahtev = zahtevZaPonudomRepository.Find(z => z.Id == model.ZahtevId, include: "PonudaKupcu").FirstOrDefault();
            if (zahtev == null)
            {
                return BadRequest("Zahtev ne postoji");
            }

            if (zahtev.PonudaKupcu != null)
            {
                return BadRequest("Zahtev vec ima ponudu.");
            }

            var ponuda = new Ponuda
            {
                Datum = model.Datum,
                Napomena = model.Napomena,
                ZahtevId = model.ZahtevId
            };
            ponudaRepository.Insert(ponuda);
            ponudaRepository.Save();
            return Ok(ponuda);
        }

        [HttpPost("{id}/stavke")]
        public IActionResult UpdateStavke(int id, [FromBody]List<StavkaPonudeModel> stavke)
        {
            var ponuda = ponudaRepository.Find(p => p.Id == id, include: "StavkePonude").FirstOrDefault();

            if (ponuda == null)
            {
                return NotFound("Ponuda nije pronadjena");
            }

            if (stavke.Any(s => s.PonudaId != id))
            {
                return BadRequest($"Stavke moraju da budu vezane za ponudu sa id-em: {id}");
            }

            var stavkeZaDelete = ponuda.StavkePonude.Where(s => !stavke.Any(sdb => sdb.ProizvodId == s.ProizvodId));

            for (int i = stavkeZaDelete.Count() - 1; i >= 0; i--)
            {
                var stavkaZaDelete = stavkeZaDelete.ElementAt(i);
                ponuda.StavkePonude.Remove(stavkaZaDelete);
            }

            var stavkeZaUpdate = stavke.Where(s => ponuda.StavkePonude.Any(sdb => sdb.ProizvodId == s.ProizvodId));
            foreach (var stavka in stavkeZaUpdate)
            {
                var stavkaZaUpdate = ponuda.StavkePonude.First(s => s.ProizvodId == stavka.ProizvodId);
                stavkaZaUpdate.Kolicnina = stavka.Kolicnina;
                stavkaZaUpdate.StatusPonude = stavka.StatusPonude;
            }

            var stavkeZaInsert = stavke.Where(s => !ponuda.StavkePonude.Any(sdb => sdb.ProizvodId == s.ProizvodId));
            foreach (var stavka in stavkeZaInsert)
            {
                var stavkaZaInsert = new StavkaPonude
                {
                    PonudaId = stavka.PonudaId,
                    Kolicnina = stavka.Kolicnina,
                    ProizvodId = stavka.ProizvodId,
                    StatusPonude = stavka.StatusPonude
                };

                ponuda.StavkePonude.Add(stavkaZaInsert);
            }

            ponudaRepository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]PonudaModel model)
        {
            var ponuda = ponudaRepository.GetById(id);
            if (ponuda == null)
            {
                return NotFound("Ta ponuda ne postoji");
            }

            ponuda.Datum = model.Datum;
            ponuda.Napomena = model.Napomena;

            ponudaRepository.Save();

            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ponuda = ponudaRepository.GetById(id);
            if (ponuda == null)
            {
                return NotFound("Ta ponuda ne postoji");
            }

            ponudaRepository.Delete(ponuda);
            ponudaRepository.Save();

            return new NoContentResult();
        }
    }
}