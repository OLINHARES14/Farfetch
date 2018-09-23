using Farfetch.App.Messages;
using Farfetch.Domain.HttpServices;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Contracts
{
    public interface IOrderAppService
    {
        Task<HttpResult<OrderRegisterMessageResponse>> Register(OrderRegisterMessageRequest request);        
    }
}
