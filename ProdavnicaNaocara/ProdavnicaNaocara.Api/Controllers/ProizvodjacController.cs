using Microsoft.AspNetCore.Mvc;
using ProdavnicaNaocara.Common.Models;
using ProdavnicaNaocara.Data;
using ProdavnicaNaocara.Data.Entities;
using ProdavnicaNaocara.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdavnicaNaocara.Api.Controllers
{
    [Route("proizvodjaci")]
    public class ProizvodjacController : BaseController
    {
        private ProizvodiRepository proizvodiRepository;
        private ProizvodjaciRepository proizvodjaciRepository;

        public ProizvodjacController(ProizvodiRepository proizvodiRepository, ProizvodjaciRepository proizvodjaciRepository)
        {
            this.proizvodiRepository = proizvodiRepository;
            this.proizvodjaciRepository = proizvodjaciRepository;
        }

        [HttpGet("model", Name = "GetProizvodjac")]
        public IActionResult getAllbyModel()
        {
            var proizvodjaci = proizvodjaciRepository.GetAllProizvodjacModels();
            return Ok(proizvodjaci);

        }

        [HttpGet]
        public IActionResult getAll()
        {
            var proizvodjaci = proizvodjaciRepository.GetAll();
            return Ok(proizvodjaci);

        }

        [HttpPost]
        public IActionResult Add([FromBody]ProizvodjacModel model)
        {
            Proizvodjac proizvodjacZaBazu = new Proizvodjac
            {
                Ime = model.Ime,
                Adresa = model.Adresa
            };
            proizvodjaciRepository.Insert(proizvodjacZaBazu);
            proizvodjaciRepository.Save();
            return Ok();

            // ovo ispod nam sluzi da bi nam postman prikazao rezultat
            //  var result = proizvodjaciRepository.GetProizvodjacModelById(proizvodjacZaBazu.Id);

            // return CreatedAtRoute("GetProizvodjac", new { id = proizvodjacZaBazu.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProizvodjacModel model)
        {
            var proizvodjacIzBaze = proizvodjaciRepository.GetById(id);
            if (proizvodjacIzBaze == null)
            {
                return NotFound($"Proizvodjac sa id-jem{proizvodjacIzBaze.Id} ne postoji u bazi");
            }
            proizvodjacIzBaze.Ime = model.Ime;
            proizvodjacIzBaze.Adresa = model.Adresa;
            proizvodjaciRepository.Save();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var proizvodjacIzBaze = proizvodjaciRepository.GetById(id);

            if (proizvodjacIzBaze == null)
            {
                return NotFound($"Proizvodjac sa id-jem{proizvodjacIzBaze.Id} ne postoji u bazi");
            }
            proizvodjaciRepository.Delete(proizvodjacIzBaze);
            proizvodjaciRepository.Save();
            return new NoContentResult();
        }



    }


}
