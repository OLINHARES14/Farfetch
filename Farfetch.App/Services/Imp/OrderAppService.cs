using Farfetch.App.Mapper;
using Farfetch.App.Messages;
using Farfetch.App.Services.Contracts;
using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Infra.Cross.Helpers;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Imp
{
    public class OrderAppService : IOrderAppService
    {
        private IOrderServiceTask OrderServiceTask { get; }

        public OrderAppService(IOrderServiceTask orderServiceTask)
        {
            OrderServiceTask = orderServiceTask;
        }

        public async Task<HttpResult<OrderRegisterMessageResponse>> Register(OrderRegisterMessageRequest request)
        {
            var retorno = new HttpResult<OrderRegisterMessageResponse>();

            if (request == null) return new HttpResult<OrderRegisterMessageResponse>().SetHttpStatusToBadRequest();
             
            var retornoTaskRegister = OrderServiceTask.Register(
                MapToModelOrder.MapToModel(request), 
                request.GetHeader(ServiceConstants.AUTHORIZATION), 
                request.GetHeader(ServiceConstants.ROTA));

            retorno.Response = MapToResponseOrderRegisterMessage.MapToOrderRegisterMessageResponse(retornoTaskRegister.Response);
            retorno.Message = retornoTaskRegister.Message;

            return retorno;
        }
    }
}
