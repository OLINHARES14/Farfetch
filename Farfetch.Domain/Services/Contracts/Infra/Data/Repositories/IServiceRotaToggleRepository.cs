using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Infra.Data.Repositories
{
    public interface IServiceRotaToggleRepository : IRepository<ServiceRotaToggle>
    {
        Task<List<ServiceRotaToggle>> GetAll();
        Task<ServiceRotaToggle> Get(int id);
    }
}