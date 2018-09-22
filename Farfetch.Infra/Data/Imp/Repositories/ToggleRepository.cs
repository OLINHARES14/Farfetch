﻿using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories;
using Farfetch.Infra.Data.Imp.Contexts;
using Farfetch.Infra.Data.Imp.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Farfetch.Infra.Data.Imp.Repositories
{
    public class ToggleRepository : Repository<Toggle>, IToggleRepository
    {
        public ToggleRepository(DbContextFarfetch context) : base(context) { }

        public async Task<Toggle> Get(int id) => await Context.Toggle.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}
