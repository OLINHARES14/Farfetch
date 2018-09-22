using Farfetch.App.Messages;
using Farfetch.Domain.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Contracts
{
    public interface IServiceRotaToggleAppService
    {
        Task<HttpResult<ServiceRotaToggleMessageResponse>> Create(ServiceRotaToggleCreateMessageRequest request);
        Task<HttpResult<List<ServiceRotaToggleMessageResponse>>> GetAll();
        Task<HttpResult<ServiceRotaToggleMessageResponse>> Get(int id);
        Task<HttpResult<ServiceRotaToggleMessageResponse>> Update(int id, ServiceRotaToggleUpdateMessageRequest request);
        Task<HttpResult<ServiceRotaToggleMessageResponse>> Delete(int id);
    }
}
