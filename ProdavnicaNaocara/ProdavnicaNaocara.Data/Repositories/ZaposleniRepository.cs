using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class ZaposleniRepository : BaseRepository<Zaposleni>
    {
        public ZaposleniRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {
        }

    }
}
