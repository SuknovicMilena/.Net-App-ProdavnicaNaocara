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
    [Route("mesta")]
    public class MestoController : BaseController
    {
        private MestoRepository MestoRepository;

        public MestoController(MestoRepository MestoRepository)
        {
            this.MestoRepository = MestoRepository;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var mesta = MestoRepository.GetAllMesta();
            return Ok(mesta);
        }
        [HttpPost]
        public IActionResult Add([FromBody]MestoModel model)
        {
            var mesto = new Mesto
            {
                Naziv = model.Naziv
            };
            MestoRepository.Insert(mesto);
            MestoRepository.Save();
            return Ok();

        }
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody]MestoModel model)
        {
            var mesto = MestoRepository.GetById(Id);
            if (mesto == null)
            {
                return NotFound("Trazeno mesto ne postoji u bazi.");
            }
            mesto.Naziv = model.Naziv;
            MestoRepository.Save();
            return new NoContentResult();

        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var mesto = MestoRepository.GetById(Id);
            if (mesto == null)
            {
                return NotFound("Trazeno mesto ne postoji u bazi.");
            }
            MestoRepository.Delete(mesto);
            MestoRepository.Save();
            return new NoContentResult();
        }
    }
}