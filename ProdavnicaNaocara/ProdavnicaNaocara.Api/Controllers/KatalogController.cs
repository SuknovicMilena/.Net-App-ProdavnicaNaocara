using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ProdavnicaNaocara.Common.Models;
using ProdavnicaNaocara.Data.Entities;
using ProdavnicaNaocara.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdavnicaNaocara.Api.Controllers
{
    [Route("katalozi")]
    public class KatalogController : BaseController
    {
        private KatalogRepository katalogRepository;
        public KatalogController(KatalogRepository katalogRepository)
        {
            this.katalogRepository = katalogRepository;

        }
        [HttpGet]
        public IActionResult GetAllKatalogModel()
        {

            var katalozi = katalogRepository.GetAllKatalogModels();
            return Ok(katalozi);
        }
        [HttpPost]
        public IActionResult Add([FromBody] KatalogModel katModel)
        {
            Katalog katalog = new Katalog
            {

                Naziv = katModel.Naziv
            };
            katalogRepository.Insert(katalog);
            katalogRepository.Save();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]KatalogModel model)
        {
            var katalogIzBaze = katalogRepository.GetById(id);
            if (katalogIzBaze == null)
            {
                BadRequest("Ne postoji taj katalog.");
            }
            katalogIzBaze.Naziv = model.Naziv;
            katalogRepository.Save();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var katalogIzBaze = katalogRepository.GetById(id);
            if (katalogIzBaze == null)
            {
                BadRequest("Ne postoji taj katalog.");
            }
            katalogRepository.Delete(katalogIzBaze);
            katalogRepository.Save();
            return new NoContentResult();
        }
    }
}
