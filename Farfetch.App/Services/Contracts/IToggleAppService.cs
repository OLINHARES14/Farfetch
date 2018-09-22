using Farfetch.App.Messages;
using Farfetch.Domain.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Contracts
{
    public interface IToggleAppService
    {
        Task<HttpResult<ToggleMessageResponse>> Create(ToggleCreateMessageRequest request);
        Task<HttpResult<List<ToggleMessageResponse>>> GetAll();
        Task<HttpResult<ToggleMessageResponse>> Get(int id);
        Task<HttpResult<ToggleMessageResponse>> Update(int id, ToggleUpdateMessageRequest request);
        Task<HttpResult<ToggleMessageResponse>> Delete(int id);
    }
}
