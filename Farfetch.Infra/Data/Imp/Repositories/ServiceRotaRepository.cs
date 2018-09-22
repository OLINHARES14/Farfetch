using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories;
using Farfetch.Infra.Data.Imp.Contexts;
using Farfetch.Infra.Data.Imp.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farfetch.Infra.Data.Imp.Repositories
{
    public class ServiceRotaRepository : Repository<ServiceRota>, IServiceRotaRepository
    {
        public ServiceRotaRepository(DbContextFarfetch context) : base(context) { }

        public async Task<List<ServiceRota>> GetAll() => await Context.ServiceRota
                .Include(it => it.ToggleServiceRotas)
            .ToListAsync();

        public async Task<ServiceRota> Get(int id) => await Context.ServiceRota.Where(x => x.Id == id)
                .Include(it => it.ToggleServiceRotas)
            .FirstOrDefaultAsync();
    }
}
