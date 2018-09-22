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
    public class ServiceRotaToggleServiceTask : BaseService, IServiceRotaToggleServiceTask
    {
        private IToggleEntityService ToggleEntityService { get; }
        private IServiceRotaToggleEntityService ServiceRotaToggleEntityService { get; }

        public ServiceRotaToggleServiceTask(IUnitOfWork unitOfWork,
            IToggleEntityService toggleEntityService,
            IServiceRotaToggleEntityService serviceRotaToggleEntityService
            ) : base(unitOfWork)
        {
            ToggleEntityService = toggleEntityService;
            ServiceRotaToggleEntityService = serviceRotaToggleEntityService;
        }

        public HttpResult<ServiceRotaToggle> Create(ServiceRotaToggle serviceRotaToggle, int toggleId)
        {
            var retorno = new HttpResult<ServiceRotaToggle>();

            var retornoToggleGet = ToggleEntityService.Get(toggleId);
            if (retornoToggleGet == null) return retorno.SetHttpStatusToNotFound();

            serviceRotaToggle.Toggle = retornoToggleGet.Result;

            _dbContext.Context.ServiceRotaToggle.Add(serviceRotaToggle);

            _dbContext.SaveChanges();

            retorno.Response = serviceRotaToggle;
            retorno.SetHttpStatusToCreated();

            return retorno;
        }

        public async Task<HttpResult<List<ServiceRotaToggle>>> GetAll()
        {
            var retorno = new HttpResult<List<ServiceRotaToggle>>();
            retorno.Response = new List<ServiceRotaToggle>();

            var retornoServiceRotaToggleGetAll = ServiceRotaToggleEntityService.GetAll();

            if (retornoServiceRotaToggleGetAll != null && retornoServiceRotaToggleGetAll.Result != null)
            {
                retorno.Response.AddRange(retornoServiceRotaToggleGetAll.Result);
            }
            
            retorno.SetHttpStatusToOk();

            return retorno;
        }

        public async Task<HttpResult<ServiceRotaToggle>> Get(int id)
        {
            var retorno = new HttpResult<ServiceRotaToggle>();

            var retornoServiceRotaToggleGet = await ServiceRotaToggleEntityService.Get(id);

            if (retornoServiceRotaToggleGet == null) return retorno.SetHttpStatusToNotFound();

            retorno.Response = retornoServiceRotaToggleGet;
            retorno.SetHttpStatusToOk();

            return retorno;
        }

        public async Task<HttpResult<ServiceRotaToggle>> Update(int id, string rota)
        {
            var retorno = new HttpResult<ServiceRotaToggle>();

            var retornoServiceRotaToggleGet = await ServiceRotaToggleEntityService.Get(id);
            if (retornoServiceRotaToggleGet == null) return retorno.SetHttpStatusToNotFound();

            retornoServiceRotaToggleGet.Rota = rota;

            _dbContext.SaveChanges();

            retorno.Response = retornoServiceRotaToggleGet;
            retorno.SetHttpStatusToOk();

            return retorno;
        }

        public async Task<HttpResult<ServiceRotaToggle>> Delete(int id)
        {
            var retorno = new HttpResult<ServiceRotaToggle>();

            var retornoServiceRotaToggleGet = await ServiceRotaToggleEntityService.Get(id);

            if (retornoServiceRotaToggleGet == null) return retorno.SetHttpStatusToNotFound();

            retornoServiceRotaToggleGet.Active = false;

            _dbContext.SaveChanges();

            retorno.Response = retornoServiceRotaToggleGet;
            retorno.Set((HttpStatusCode)204, "Service Rota Toggle delete");

            return retorno;
        }
    }
}
