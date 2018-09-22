using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories;
using Farfetch.Infra.Data.Imp.Contexts;
using Farfetch.Infra.Data.Imp.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Farfetch.Infra.Data.Imp.Repositories
{
    public class ServiceRotaToggleRepository : Repository<ServiceRotaToggle>, IServiceRotaToggleRepository
    {
        public ServiceRotaToggleRepository(DbContextFarfetch context) : base(context) { }

        public async Task<ServiceRotaToggle> Get(int id) => await Context.ServiceRotaToggle.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}
