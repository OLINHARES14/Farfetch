using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Domain.Services.Imp.Entities.Base;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Imp.Tasks
{
    public class ServiceRotaServiceTask : BaseService, IServiceRotaServiceTask
    {
        private IServiceRotaEntityService ServiceRotaEntityService { get; }

        public ServiceRotaServiceTask(IUnitOfWork unitOfWork,
            IServiceRotaEntityService serviceRotaEntityService
            ) : base(unitOfWork)
        {
            ServiceRotaEntityService = serviceRotaEntityService;
        }

        public HttpResult<ServiceRota> Create(ServiceRota serviceRota)
        {
            var retorno = new HttpResult<ServiceRota>();
            
            _dbContext.Context.ServiceRota.Add(serviceRota);

            _dbContext.SaveChanges();

            retorno.Response = serviceRota;
            retorno.SetHttpStatusToCreated();

            return retorno;
        }

        public async Task<HttpResult<List<ServiceRota>>> GetAll()
        {
            var retorno = new HttpResult<List<ServiceRota>>();
            retorno.Response = new List<ServiceRota>();

            var retornoServiceRotaGetAll = ServiceRotaEntityService.GetAll();

            if (retornoServiceRotaGetAll != null && retornoServiceRotaGetAll.Result != null)
            {
                retorno.Response.AddRange(retornoServiceRotaGetAll.Result);
            }
            
            retorno.SetHttpStatusToOk();

            return retorno;
        }

        public async Task<HttpResult<ServiceRota>> Get(int id)
        {
            var retorno = new HttpResult<ServiceRota>();

            var retornoServiceRotaGet = await ServiceRotaEntityService.Get(id);

            if (retornoServiceRotaGet == null) return retorno.SetHttpStatusToNotFound();

            retorno.Response = retornoServiceRotaGet;
            retorno.SetHttpStatusToOk();

            return retorno;
        }

        public async Task<HttpResult<ServiceRota>> Update(int id, string rota)
        {
            var retorno = new HttpResult<ServiceRota>();

            var retornoServiceRotaGet = await ServiceRotaEntityService.Get(id);

            if (retornoServiceRotaGet == null) return retorno.SetHttpStatusToNotFound();

            retornoServiceRotaGet.Rota = rota;

            _dbContext.SaveChanges();

            retorno.Response = retornoServiceRotaGet;
            retorno.SetHttpStatusToOk();

            return retorno;
        }

        public async Task<HttpResult<ServiceRota>> Delete(int id)
        {
            var retorno = new HttpResult<ServiceRota>();

            var retornoServiceRotaGet = await ServiceRotaEntityService.Get(id);

            if (retornoServiceRotaGet == null) return retorno.SetHttpStatusToNotFound();

            retornoServiceRotaGet.Active = false;

            _dbContext.SaveChanges();

            retorno.Response = retornoServiceRotaGet;
            retorno.Set((HttpStatusCode)204, "Service Rota delete");

            return retorno;
        }
    }
}
