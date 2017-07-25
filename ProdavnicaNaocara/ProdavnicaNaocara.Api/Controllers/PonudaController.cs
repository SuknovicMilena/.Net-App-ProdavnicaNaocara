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

        public PonudaController(PonudaRepository ponudaRepository)
        {
            this.ponudaRepository = ponudaRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ponude = ponudaRepository.GetAllPonudaModel();
            return Ok(ponude);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var ponuda = ponudaRepository.GetAllPonudaModelById(Id);
            return Ok(ponuda);
        }
        [HttpPost]
        public IActionResult Add([FromBody]PonudaModel model)
        {
            var ponuda = new Ponuda
            {
                Datum = model.Datum,
                Napomena = model.Napomena
            };
            ponudaRepository.Insert(ponuda);
            ponudaRepository.Save();
            return Ok();
        }
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody]PonudaModel model)
        {
            var ponuda = ponudaRepository.GetById(Id);
            if (ponuda == null)
            {
                NotFound("Ta ponuda ne postoji");
            }

            ponuda.Datum = model.Datum;
            ponuda.Napomena = model.Napomena;

            ponudaRepository.Save();

            return new NoContentResult();
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var ponuda = ponudaRepository.GetById(Id);
            if (ponuda == null)
            {
                NotFound("Taj proizvod ne postoji");
            }

            ponudaRepository.Delete(ponuda);
            ponudaRepository.Save();

            return new NoContentResult();
        }
    }
}