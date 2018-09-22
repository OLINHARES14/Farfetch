using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Tasks
{
    public interface IServiceRotaToggleServiceTask
    {
        HttpResult<ServiceRotaToggle> Create(ServiceRotaToggle serviceRotaToggle, int toggleId);
        Task<HttpResult<List<ServiceRotaToggle>>> GetAll();
        Task<HttpResult<ServiceRotaToggle>> Get(int id);
        Task<HttpResult<ServiceRotaToggle>> Update(int id, string rota);
        Task<HttpResult<ServiceRotaToggle>> Delete(int id);
    }
}
