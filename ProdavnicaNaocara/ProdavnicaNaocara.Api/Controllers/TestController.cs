using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Common.Models;
using ProdavnicaNaocara.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdavnicaNaocara.Api.Controllers
{
    [Route("test")]
    public class TestController : BaseController
    {
        private ProdavnicaNaocaraDbContext db;

        public TestController(ProdavnicaNaocaraDbContext db)
        {
            this.db = db;
        }

        [HttpGet("hello")]
        public IActionResult HelloWorld()
        {
            return Ok("Hello!");
        }

        [HttpGet("json")]
        public IActionResult JsonResult()
        {
            return Ok(new { Name = "Milena", Role = "Dusa" });
        }

        [HttpGet("proizvodi")]
        public IActionResult GetProizvodi()
        {
            //var proizvodi = db.Proizvodi.Include(p => p.Proizvodjac).ToList();
            var proizvodi = db.Proizvodi.ToList();
            return Ok(proizvodi);
        }

        [HttpGet("proizvodjaci")]
        public IActionResult GetProizvodjaci()
        {
            var proizvodjaci = db.Proizvodjaci.ToList();
            return Ok(proizvodjaci);
        }

        [HttpGet("proizvodi-model")]
        public IActionResult GetProizvodiModel()
        {
            var proizvodi = db.Proizvodi.Select(p => new ProizvodModel
            {
                Id = p.Id,
                Ime = p.Ime,
                Tip = p.Tip,
                ProizvodjacId = p.ProizvodjacId, 
                ProizvodjacIme = p.Proizvodjac.Ime
            }).ToList();
            return Ok(proizvodi);
        }
        

    }
}
