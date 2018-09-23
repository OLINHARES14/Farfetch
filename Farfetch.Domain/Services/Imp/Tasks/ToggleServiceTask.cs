using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Domain.Services.Imp.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Imp.Tasks
{
    public class ToggleServiceTask : BaseService, IToggleServiceTask
    {
        private IToggleEntityService ToggleEntityService { get; }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }

        public ToggleServiceTask(IUnitOfWork unitOfWork,
            IToggleEntityService toggleEntityService,
            IServiceRotaEntityService serviceRotaEntityService
            ) : base(unitOfWork)
        {            
            ToggleEntityService = toggleEntityService;
            ServiceRotaEntityService = serviceRotaEntityService;
        }

        public HttpResult<Toggle> Create(Toggle toggle, List<int> idsServiceRota)
        {
            var retorno = new HttpResult<Toggle>();
            
            _dbContext.Context.Toggle.Add(toggle);

            foreach (var id in idsServiceRota)
            {
                var retornoServiceRotaGet = ServiceRotaEntityService.Get(id);
                if (retornoServiceRotaGet == null) return retorno.SetHttpStatusToNotFound();

                var toggleServiceRota = new ToggleServiceRota();
                toggleServiceRota.ServiceRota = retornoServiceRotaGet.Result;
                toggleServiceRota.Toggle = toggle;

                toggle.ToggleServiceRotas.Add(toggleServiceRota);
            }

            _dbContext.SaveChanges();

            retorno.Response = toggle;
            retorno.SetHttpStatusToCreated();

            return retorno;
        }

        public async Task<HttpResult<List<Toggle>>> GetAll()
        {
            var retorno = new HttpResult<List<Toggle>>();
            retorno.Response = new List<Toggle>();

            var retornoToggleGetAll = ToggleEntityService.GetAll();
            if (retornoToggleGetAll != null && retornoToggleGetAll.Result != null)
            {
                retorno.Response.AddRange(retornoToggleGetAll.Result);
            }
            
            retorno.SetHttpStatusToOk();

            return retorno;
        }

        public async Task<HttpResult<Toggle>> Get(int id)
        {
            var retorno = new HttpResult<Toggle>();

            var retornoToggleGet = await ToggleEntityService.Get(id);
            if (retornoToggleGet == null) return retorno.SetHttpStatusToNotFound();

            retorno.Response = retornoToggleGet;
            retorno.SetHttpStatusToOk();

            return retorno;
        }

        public async Task<HttpResult<Toggle>> Update(int id, string description, bool flag, List<int> idsServiceRota)
        {
            var retorno = new HttpResult<Toggle>();

            var retornoToggleGet = await ToggleEntityService.Get(id);
            if (retornoToggleGet == null) return retorno.SetHttpStatusToNotFound();

            retornoToggleGet.Description = description;
            retornoToggleGet.Flag = flag;

            foreach (var idServiceRota in idsServiceRota)
            {
                var retornoServiceRotaGet = ServiceRotaEntityService.Get(idServiceRota);
                if (retornoServiceRotaGet == null) return retorno.SetHttpStatusToNotFound();

                retornoToggleGet.ToggleServiceRotas = null;

                var toggleServiceRota = new ToggleServiceRota();
                toggleServiceRota.ServiceRota = retornoServiceRotaGet.Result;
                toggleServiceRota.Toggle = retornoToggleGet;

                retornoToggleGet.ToggleServiceRotas.Add(toggleServiceRota);
            }

            _dbContext.SaveChanges();

            retorno.Response = retornoToggleGet;
            retorno.SetHttpStatusToOk();

            return retorno;
        }

        public async Task<HttpResult<Toggle>> Delete(int id)
        {
            var retorno = new HttpResult<Toggle>();

            var retornoToggleGet = await ToggleEntityService.Get(id);
            if (retornoToggleGet == null) return retorno.SetHttpStatusToNotFound();

            retornoToggleGet.Active = false;

            _dbContext.SaveChanges();

            retorno.Response = retornoToggleGet;
            retorno.SetHttpStatusToOk();

            return retorno;
        }
    }
}
