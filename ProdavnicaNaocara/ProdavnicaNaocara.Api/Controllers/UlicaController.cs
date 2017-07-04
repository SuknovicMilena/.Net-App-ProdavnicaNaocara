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
    [Route("ulice")]
    public class UlicaController : BaseController
    {
        private MestoRepository MestoRepository;
        private UlicaRepostitory UlicaRepostitory;

        public UlicaController(MestoRepository MestoRepository, UlicaRepostitory UlicaRepostitory)
        {
            this.MestoRepository = MestoRepository;
            this.UlicaRepostitory = UlicaRepostitory;

        }
        [HttpGet]
        public IActionResult GetAllUlice()
        {
            var ulice = UlicaRepostitory.GetAllUlica();
            return Ok(ulice);

        }
        [HttpGet("{Id}")]
        public IActionResult GetAllUliceById(int Id)
        {
            var ulica = UlicaRepostitory.GetById(Id);
            return Ok(ulica);

        }
        [HttpPost]
        public IActionResult Add([FromBody]UlicaModel model)
        {
            var mesto = MestoRepository.GetById(model.MestoId);
            if (mesto == null)
            {
                BadRequest("Izabrano mesto ne postoji!");
            }
            var ulica = new Ulica
            {
                Naziv = model.Naziv,
                MestoId = model.MestoId
            };

            UlicaRepostitory.Insert(ulica);
            UlicaRepostitory.Save();
            return Ok();
        }
        [HttpPost("{Id}")]
        public IActionResult Update(int Id, [FromBody]UlicaModel model)
        {

            var ulica = UlicaRepostitory.GetById(Id);
            if (ulica == null)
            {
                BadRequest("Izabrana ulica ne postoji!");
            }
            var mesto = MestoRepository.GetById(model.MestoId);
            if (mesto == null)
            {
                BadRequest("Izabrano mesto ne postoji!");
            }
            ulica.Naziv = model.Naziv;
            ulica.MestoId = model.MestoId;

            UlicaRepostitory.Save();
            return new NoContentResult();

        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var ulica = UlicaRepostitory.GetById(Id);
            if (ulica == null)
            {
                BadRequest("Izabrana ulica ne postoji!");
            }

            UlicaRepostitory.Delete(ulica);
            UlicaRepostitory.Save();
            return new NoContentResult();
        }
    }


}
