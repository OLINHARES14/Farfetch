using Farfetch.App.Mapper;
using Farfetch.App.Messages;
using Farfetch.App.Services.Contracts;
using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Infra.Cross.Helpers;
using System.Collections.Generic;
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

            if (request == null) return retorno.SetHttpStatusToBadRequest();
             
            var retornoTaskRegister = OrderServiceTask.Register(
                MapToModelOrder.MapToModel(request), 
                request.GetHeader(ServiceConstants.AUTHORIZATION), 
                request.GetHeader(ServiceConstants.ROTA));

            retorno.Response = MapToResponseOrderRegisterMessage.MapToOrderRegisterMessageResponse(retornoTaskRegister.Response);
            retorno.Message = retornoTaskRegister.Message;

            return retorno;
        }

        public async Task<HttpResult<List<OrderRegisterMessageResponse>>> GetAll()
        {
            var retorno = new HttpResult<List<OrderRegisterMessageResponse>>();
            retorno.Response = new List<OrderRegisterMessageResponse>();

            var retornoTaskGetAll = OrderServiceTask.GetAll();

            retorno.Response = MapToResponseOrderRegisterMessage.MapToListOrderRegisterMessageResponse(retornoTaskGetAll.Result.Response);
            retorno.Message = retornoTaskGetAll.Result.Message;

            return retorno;
        }

        public async Task<HttpResult<OrderRegisterMessageResponse>> Get(int id)
        {
            var retorno = new HttpResult<OrderRegisterMessageResponse>();

            if (id <= 0) return retorno.SetToUnprocessableEntity(ServiceConstants.IDENTIFICADOR_INVALIDO);

            var retornoTaskGet = OrderServiceTask.Get(id);

            retorno.Response = MapToResponseOrderRegisterMessage.MapToOrderRegisterMessageResponse(retornoTaskGet.Result.Response);
            retorno.Message = retornoTaskGet.Result.Message;

            return retorno;
        }
    }
}
