using Farfetch.App.Messages;
using Farfetch.Domain.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Contracts
{
    public interface IOrderAppService
    {
        Task<HttpResult<OrderRegisterMessageResponse>> Register(OrderRegisterMessageRequest request);
        Task<HttpResult<List<OrderRegisterMessageResponse>>> GetAll();
        Task<HttpResult<OrderRegisterMessageResponse>> Get(int id);
    }
}
