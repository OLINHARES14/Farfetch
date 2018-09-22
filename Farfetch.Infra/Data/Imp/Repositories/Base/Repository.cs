using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories.Base;
using Farfetch.Infra.Data.Imp.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Infra.Data.Imp.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContextFarfetch Context { get;  }

        public Repository(DbContextFarfetch context) { Context = context; }

        public async Task<List<TEntity>> GetAll() => await Context.Set<TEntity>().ToListAsync();
    }
}
