﻿using Farfetch.App.Mapper;
using Farfetch.App.Messages;
using Farfetch.App.Services.Contracts;
using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Infra.Cross.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.App.Services.Imp
{
    public class ServiceRotaToggleAppService : IServiceRotaToggleAppService
    {
        private IServiceRotaToggleServiceTask ServiceRotaToggleServiceTask { get; }

        public ServiceRotaToggleAppService(IServiceRotaToggleServiceTask serviceRotaToggleServiceTask)
        {
            ServiceRotaToggleServiceTask = serviceRotaToggleServiceTask;
        }

        public async Task<HttpResult<ServiceRotaToggleMessageResponse>> Create(ServiceRotaToggleCreateMessageRequest request)
        {
            var retorno = new HttpResult<ServiceRotaToggleMessageResponse>();

            if (request == null) return retorno.SetHttpStatusToBadRequest();
                        
            var retornoTaskCreate = ServiceRotaToggleServiceTask.Create(MapToModelServiceRotaToggle.MapToModel(request), request.toggleId);

            retorno.Response = MapToResponseServiceRotaToggleMessage.MapToServiceRotaToggleMessageResponse(retornoTaskCreate.Response);
            retorno.Message = retornoTaskCreate.Message;

            return retorno;
        }

        public async Task<HttpResult<List<ServiceRotaToggleMessageResponse>>> GetAll()
        {
            var retorno = new HttpResult<List<ServiceRotaToggleMessageResponse>>();            
            retorno.Response = new List<ServiceRotaToggleMessageResponse>();

            var retornoTaskGetAll = ServiceRotaToggleServiceTask.GetAll();

            retorno.Response = MapToResponseServiceRotaToggleMessage.MapToListServiceRotaToggleMessageResponse(retornoTaskGetAll.Result.Response);
            retorno.Message = retornoTaskGetAll.Result.Message;

            return retorno;
        }

        public async Task<HttpResult<ServiceRotaToggleMessageResponse>> Get(int id)
        {
            var retorno = new HttpResult<ServiceRotaToggleMessageResponse>();

            if (id <= 0) return retorno.SetToUnprocessableEntity(ServiceConstants.IDENTIFICADOR_INVALIDO);

            var retornoTaskGet = ServiceRotaToggleServiceTask.Get(id);

            retorno.Response = MapToResponseServiceRotaToggleMessage.MapToServiceRotaToggleMessageResponse(retornoTaskGet.Result.Response);
            retorno.Message = retornoTaskGet.Result.Message;

            return retorno;
        }

        public async Task<HttpResult<ServiceRotaToggleMessageResponse>> Update(int id, ServiceRotaToggleUpdateMessageRequest request)
        {
            var retorno = new HttpResult<ServiceRotaToggleMessageResponse>();

            if (id <= 0) return retorno.SetToUnprocessableEntity(ServiceConstants.IDENTIFICADOR_INVALIDO);
            if (request == null) return retorno.SetHttpStatusToBadRequest();
                        
            var retornoTaskUpdate = ServiceRotaToggleServiceTask.Update(id, request.Rota, request.ToggleId);
                        
            retorno.Response = MapToResponseServiceRotaToggleMessage.MapToServiceRotaToggleMessageResponse(retornoTaskUpdate.Result.Response);
            retorno.Message = retornoTaskUpdate.Result.Message;

            return retorno;
        }

        public async Task<HttpResult<ServiceRotaToggleMessageResponse>> Delete(int id)
        {
            var retorno = new HttpResult<ServiceRotaToggleMessageResponse>();

            if (id <= 0) return retorno.SetToUnprocessableEntity(ServiceConstants.IDENTIFICADOR_INVALIDO);

            var retornoTaskDelete = ServiceRotaToggleServiceTask.Delete(id);

            retorno.Response = MapToResponseServiceRotaToggleMessage.MapToServiceRotaToggleMessageResponse(retornoTaskDelete.Result.Response);
            retorno.Message = retornoTaskDelete.Result.Message;

            return retorno;
        }
    }
}