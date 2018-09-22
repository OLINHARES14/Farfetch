using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Infra.Data.Repositories
{
    public interface IToggleRepository : IRepository<Toggle>
    {
        Task<List<Toggle>> GetAll();
        Task<Toggle> Get(int id);
    }
}