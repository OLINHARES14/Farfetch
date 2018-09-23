using Farfetch.App.Mapper;
using Farfetch.App.Messages;
using Farfetch.App.Services.Contracts;
using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Services.Contracts.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Imp
{
    public class ServiceRotaAppService : IServiceRotaAppService
    {
        private IServiceRotaServiceTask ServiceRotaServiceTask { get; }

        public ServiceRotaAppService(IServiceRotaServiceTask serviceRotaServiceTask)
        {
            ServiceRotaServiceTask = serviceRotaServiceTask;
        }

        public async Task<HttpResult<ServiceRotaMessageResponse>> Create(ServiceRotaCreateMessageRequest request)
        {
            var retorno = new HttpResult<ServiceRotaMessageResponse>();

            if (request == null) return new HttpResult<ServiceRotaMessageResponse>().SetHttpStatusToBadRequest();
            
            var retornoTaskCreate = ServiceRotaServiceTask.Create(MapToModelServiceRota.MapToModel(request));

            retorno.Response = MapToResponseServiceRotaMessage.MapToServiceRotaMessageResponse(retornoTaskCreate.Response);
            retorno.Message = retornoTaskCreate.Message;

            return retorno;
        }

        public async Task<HttpResult<List<ServiceRotaMessageResponse>>> GetAll()
        {
            var retorno = new HttpResult<List<ServiceRotaMessageResponse>>();            
            retorno.Response = new List<ServiceRotaMessageResponse>();

            var retornoTaskGetAll = ServiceRotaServiceTask.GetAll();

            retorno.Response = MapToResponseServiceRotaMessage.MapToListServiceRotaMessageResponse(retornoTaskGetAll.Result.Response);
            retorno.Message = retornoTaskGetAll.Result.Message;

            return retorno;
        }

        public async Task<HttpResult<ServiceRotaMessageResponse>> Get(int id)
        {
            var retorno = new HttpResult<ServiceRotaMessageResponse>();

            var retornoTaskGet = ServiceRotaServiceTask.Get(id);

            retorno.Response = MapToResponseServiceRotaMessage.MapToServiceRotaMessageResponse(retornoTaskGet.Result.Response);
            retorno.Message = retornoTaskGet.Result.Message;

            return retorno;
        }

        public async Task<HttpResult<ServiceRotaMessageResponse>> Update(int id, ServiceRotaUpdateMessageRequest request)
        {
            var retorno = new HttpResult<ServiceRotaMessageResponse>();

            if (request == null) return new HttpResult<ServiceRotaMessageResponse>().SetHttpStatusToNoContent();
                        
            var retornoTaskUpdate = ServiceRotaServiceTask.Update(id, request.Rota);
                        
            retorno.Response = MapToResponseServiceRotaMessage.MapToServiceRotaMessageResponse(retornoTaskUpdate.Result.Response);
            retorno.Message = retornoTaskUpdate.Result.Message;

            return retorno;
        }

        public async Task<HttpResult<ServiceRotaMessageResponse>> Delete(int id)
        {
            var retorno = new HttpResult<ServiceRotaMessageResponse>();

            if (id == 0)
                return new HttpResult<ServiceRotaMessageResponse>().SetHttpStatusToNoContent();

            var retornoTaskDelete = ServiceRotaServiceTask.Delete(id);

            retorno.Response = MapToResponseServiceRotaMessage.MapToServiceRotaMessageResponse(retornoTaskDelete.Result.Response);
            retorno.Message = retornoTaskDelete.Result.Message;

            return retorno;
        }
    }
}
