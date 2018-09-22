using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Infra.Data.Repositories
{
    public interface IServiceRotaRepository : IRepository<ServiceRota>
    {
        Task<List<ServiceRota>> GetAll();
        Task<ServiceRota> Get(int id);
    }
}