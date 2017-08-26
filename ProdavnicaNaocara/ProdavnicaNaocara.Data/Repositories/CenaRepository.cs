using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Common.Models;
using System.Linq;
using ProdavnicaNaocara.Data.Entities;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class CenaRepository : BaseRepository<Cena>
    {
        public CenaRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {
        }

        public List<CenaModel> GetAllCenaModels()
        {
            var cene = dbSet.Select(c => new CenaModel
            {
                Id = c.Id,
                ProizvodId = c.ProizvodId,
                ProizvodIme = c.Proizvod.Ime,
                IznosCene = c.IznosCene,
                IznosPopusta = c.IznosPopusta
            }).ToList();
            return cene;
        }
        public CenaModel GetCenaModelById(int id)
        {
            var cena = dbSet.Select(c => new CenaModel
            {
                Id = c.Id,
                ProizvodId = c.ProizvodId,
                ProizvodIme = c.Proizvod.Ime,
                IznosCene = c.IznosCene,
                IznosPopusta = c.IznosPopusta
            }).FirstOrDefault(c => c.Id == id);

            return cena;
        }




    }
}