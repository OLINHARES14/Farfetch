using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Entities
{
    public interface IToggleEntityService
    {
        Task<List<Toggle>> GetAll();
        Task<Toggle> Get(int id);
    }
}
