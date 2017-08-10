using ProdavnicaNaocara.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProdavnicaNaocara.Common.Models;
using System.Linq;

namespace ProdavnicaNaocara.Data.Repositories
{
    public class KupacRepository : BaseRepository<Kupac>
    {

        public KupacRepository(ProdavnicaNaocaraDbContext dbContext) : base(dbContext)
        {

        }
        public List<KupacModel> GetAllKupacModel()
        {
            var kupci = dbSet.Select(k => new KupacModel
            {
                Id = k.Id,
                Naziv = k.Naziv,
                BrojTelefona = k.BrojTelefona,
                AdresaId = k.AdresaId,
                AdresaNaziv = k.Adresa.Ulica.Naziv + " " + k.Adresa.Broj,




            }).ToList();
            return kupci;
        }

        public KupacModel GetKupacModelById(int id)
        {
            var kupac = dbSet.Select(k => new KupacModel
            {
                Id = k.Id,
                Naziv = k.Naziv,
                BrojTelefona = k.BrojTelefona,
                AdresaId = k.AdresaId,
                AdresaNaziv = k.Adresa.Ulica.Naziv + "" + k.Adresa.Broj



            }).FirstOrDefault(k => k.Id == id);
            return kupac;
        }

    }
}
