using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Tasks
{
    public interface IToggleServiceTask
    {
        HttpResult<Toggle> Create(Toggle toggle);
        Task<HttpResult<List<Toggle>>> GetAll();
        Task<HttpResult<Toggle>> Get(int id);
        Task<HttpResult<Toggle>> Update(int id, string description, bool flag);
        Task<HttpResult<Toggle>> Delete(int id);
    }
}
