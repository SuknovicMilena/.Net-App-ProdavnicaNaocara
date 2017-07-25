using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Common.Models;
using System.Linq;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class StavkaPonudeRepository : BaseRepository<StavkaPonude>
    {
        public StavkaPonudeRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {
        }

        public List<StavkaPonudeModel> GetAllByStavkaPonudeMode()
        {
            var stavkePonude = dbSet.Select(sp => new StavkaPonudeModel
            {
                RbStavkeId = sp.RbStavkeId,
                PonudaId = sp.PonudaId,
                Kolicnina = sp.Kolicnina,
                StatusPonude = sp.StatusPonude,
                ProizvodId = sp.ProizvodId,
                ProizvodNaziv = sp.ProizvodPonuda.Ime

            }).ToList();
            return stavkePonude;
        }
        public StavkaPonudeModel GetAllByStavkaPonudeMode(int RbStavkeId, int PonudaId)
        {
            var stavkaPonude = dbSet.Select(sp => new StavkaPonudeModel
            {

                Kolicnina = sp.Kolicnina,
                StatusPonude = sp.StatusPonude,
                ProizvodId = sp.ProizvodId,
                ProizvodNaziv = sp.ProizvodPonuda.Ime

            }).FirstOrDefault(sp => sp.RbStavkeId == RbStavkeId && sp.PonudaId == PonudaId);
            return stavkaPonude;
        }
    }
}
