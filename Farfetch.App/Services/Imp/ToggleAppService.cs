using Farfetch.App.Mapper;
using Farfetch.App.Messages;
using Farfetch.App.Services.Contracts;
using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Imp
{
    public class ToggleAppService : IToggleAppService
    {
        private IToggleServiceTask ToggleServiceTask { get; }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }

        public ToggleAppService(IToggleServiceTask toggleServiceTask, IServiceRotaEntityService serviceRotaEntityService)
        {
            ToggleServiceTask = toggleServiceTask;
            ServiceRotaEntityService = serviceRotaEntityService;
        }

        public async Task<HttpResult<ToggleMessageResponse>> Create(ToggleCreateMessageRequest request)
        {
            var retorno = new HttpResult<ToggleMessageResponse>();

            if (request == null) return new HttpResult<ToggleMessageResponse>().SetHttpStatusToBadRequest();
            
            var retornoTaskCreate = ToggleServiceTask.Create(MapToModelToggle.MapToModel(request), request.IdsServiceRota);

            retorno.Response = MapToResponseToggleMessage.MapToToggleMessageResponse(retornoTaskCreate.Response);
            retorno.Message = retornoTaskCreate.Message;

            return retorno;
        }

        public async Task<HttpResult<List<ToggleMessageResponse>>> GetAll()
        {
            var retorno = new HttpResult<List<ToggleMessageResponse>>();            
            retorno.Response = new List<ToggleMessageResponse>();

            var retornoTaskGetAll = ToggleServiceTask.GetAll();

            retorno.Response = MapToResponseToggleMessage.MapToListToggleMessageResponse(retornoTaskGetAll.Result.Response);
            retorno.Message = retornoTaskGetAll.Result.Message;

            return retorno;
        }

        public async Task<HttpResult<ToggleMessageResponse>> Get(int id)
        {
            var retorno = new HttpResult<ToggleMessageResponse>();

            var retornoTaskGet = ToggleServiceTask.Get(id);

            retorno.Response = MapToResponseToggleMessage.MapToToggleMessageResponse(retornoTaskGet.Result.Response);
            retorno.Message = retornoTaskGet.Result.Message;

            return retorno;
        }

        public async Task<HttpResult<ToggleMessageResponse>> Update(int id, ToggleUpdateMessageRequest request)
        {
            var retorno = new HttpResult<ToggleMessageResponse>();

            if (request == null) return new HttpResult<ToggleMessageResponse>().SetHttpStatusToNoContent();
                        
            var retornoTaskUpdate = ToggleServiceTask.Update(id, request.Description, request.Flag, request.IdsServiceRota);
                        
            retorno.Response = MapToResponseToggleMessage.MapToToggleMessageResponse(retornoTaskUpdate.Result.Response);
            retorno.Message = retornoTaskUpdate.Result.Message;

            return retorno;
        }

        public async Task<HttpResult<ToggleMessageResponse>> Delete(int id)
        {
            var retorno = new HttpResult<ToggleMessageResponse>();

            if (id == 0)
                return new HttpResult<ToggleMessageResponse>().SetHttpStatusToNoContent();

            var retornoTaskDelete = ToggleServiceTask.Delete(id);

            retorno.Response = MapToResponseToggleMessage.MapToToggleMessageResponse(retornoTaskDelete.Result.Response);
            retorno.Message = retornoTaskDelete.Result.Message;

            return retorno;
        }
    }
}