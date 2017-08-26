using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Common.Models;
using System.Linq;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class MestoRepository : BaseRepository<Mesto>
    {
        public MestoRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {
        }



        public List<MestoModel> GetAllMesta()
        {
            var mesta = dbSet.Select(m => new MestoModel
            {
                Id = m.Id,
                Naziv = m.Naziv
            }).ToList();
            return mesta;
        }
        public MestoModel GetMestoById(int Id)
        {
            var mesto = dbSet.Select(m => new MestoModel
            {
                Id = m.Id,
                Naziv = m.Naziv
            }).FirstOrDefault(m => m.Id == Id);
            return mesto;
        }
    }
}
