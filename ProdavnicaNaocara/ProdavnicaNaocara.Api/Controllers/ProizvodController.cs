using Microsoft.AspNetCore.Mvc;
using ProdavnicaNaocara.Common.Models;
using ProdavnicaNaocara.Data.Entities;
using ProdavnicaNaocara.Data.Repositories;
using System.Collections.Generic;
namespace ProdavnicaNaocara.Api.Controllers
{
    [Route("proizvodi")]
    public class ProizvodController : BaseController
    {
        private ProizvodiRepository proizvodiRepository;
        private ProizvodjaciRepository proizvodjacRepository;

        public ProizvodController(ProizvodiRepository proizvodiRepository, ProizvodjaciRepository proizvodjacRepository)
        {
            this.proizvodiRepository = proizvodiRepository;
            this.proizvodjacRepository = proizvodjacRepository;
        }

        [HttpGet("{id}", Name = "GetProizvod")]
        public IActionResult Get(int id)
        {
            ProizvodModel proizvod = proizvodiRepository.GetProizvodModelById(id);

            if (proizvod == null)
            {
                return NotFound($"Proizvod sa id-em {id} ne postoji.");
            }


            return Ok(proizvod);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProizvodModel> proizvodi = proizvodiRepository.GetAllProizvodModels();
            return View(proizvodi);
        }

        [HttpPost]
        public IActionResult Add([FromBody]ProizvodModel model)
        {
            var proizvodjacIzBaze = proizvodjacRepository.GetById(model.ProizvodjacId);

            if (proizvodjacIzBaze == null)
            {
                return BadRequest($"Proizvodjac sa id-em {model.ProizvodjacId} ne postoji!");
            }

            var proizvodZaBazu = new Proizvod
            {
                Ime = model.Ime,
                ProizvodjacId = model.ProizvodjacId,
                Tip = model.Tip
            };

            proizvodiRepository.Insert(proizvodZaBazu);
            proizvodiRepository.Save();

            var result = proizvodiRepository.GetProizvodModelById(proizvodZaBazu.Id);

            return CreatedAtRoute("GetProizvod", new { id = proizvodZaBazu.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ProizvodModel model)
        {
            var proizvodIzBaze = proizvodiRepository.GetById(id);

            if (proizvodIzBaze == null)
            {
                return NotFound($"Proizvod sa id-em {id} ne postoji.");
            }


            var proizvodjacIzBaze = proizvodjacRepository.GetById(model.ProizvodjacId);

            if (proizvodjacIzBaze == null)
            {
                return NotFound($"Proizvodjac sa id-em {model.ProizvodjacId} ne postoji!");
            }

            proizvodIzBaze.Ime = model.Ime;
            proizvodIzBaze.ProizvodjacId = model.ProizvodjacId;
            proizvodIzBaze.Tip = model.Tip;

            proizvodiRepository.Save();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var proizvodIzBaze = proizvodiRepository.GetById(id);

            if (proizvodIzBaze == null)
            {
                return NotFound($"Proizvod sa id-em {id} ne postoji.");
            }

            proizvodiRepository.Delete(proizvodIzBaze);
            proizvodiRepository.Save();

            return new NoContentResult();
        }
    }
}
