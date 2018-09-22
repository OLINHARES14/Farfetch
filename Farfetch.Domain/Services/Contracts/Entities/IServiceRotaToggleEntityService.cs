using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Entities
{
    public interface IServiceRotaToggleEntityService
    {
        Task<List<ServiceRotaToggle>> GetAll();
        Task<ServiceRotaToggle> Get(int id);
    }
}
