using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Tasks
{
    public interface IServiceRotaServiceTask
    {
        HttpResult<ServiceRota> Create(ServiceRota serviceRota);
        Task<HttpResult<List<ServiceRota>>> GetAll();
        Task<HttpResult<ServiceRota>> Get(int id);
        Task<HttpResult<ServiceRota>> Update(int id, string rota);
        Task<HttpResult<ServiceRota>> Delete(int id);
    }
}
