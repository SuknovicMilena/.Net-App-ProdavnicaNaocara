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
    [Route("zaposleni")]
    public class ZaposleniController : Controller
    {
        private ZaposleniRepository zaposleniRepository;

        public ZaposleniController(ZaposleniRepository zaposleniRepository)
        {
            this.zaposleniRepository = zaposleniRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var zaposleni = zaposleniRepository.GetAll();
            return Ok(zaposleni);
        }

        [HttpPost]
        public IActionResult Insert([FromBody]ZaposleniModel model)
        {
            var zaposleni = new Zaposleni
            {
                Naziv = model.Naziv
            };
            zaposleniRepository.Insert(zaposleni);
            zaposleniRepository.Save();
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody]ZaposleniModel model)
        {
            var zaposleni = zaposleniRepository.GetById(Id);
            if (zaposleni == null)
            {
                return NotFound("Ne postoji taj zaposleni.");
            }
            zaposleni.Naziv = model.Naziv;
            zaposleniRepository.Save();
            return new NoContentResult();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var zaposleni = zaposleniRepository.GetById(Id);
            if (zaposleni == null)
            {
                return NotFound("Ne postoji taj zaposleni.");
            }
            zaposleniRepository.Delete(zaposleni);
            zaposleniRepository.Save();
            return new NoContentResult();
        }
    }
}