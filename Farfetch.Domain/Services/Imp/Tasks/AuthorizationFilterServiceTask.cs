using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Domain.Services.Imp.Entities.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Imp.Tasks
{
    public class AuthorizationFilterServiceTask : BaseService, IAuthorizationFilterServiceTask
    {
        private IToggleEntityService ToggleEntityService { get; }
        private IServiceRotaEntityService ServiceRotaEntityService { get; }
        private IServiceRotaToggleEntityService ServiceRotaToggleEntityService { get; }

        public AuthorizationFilterServiceTask(IUnitOfWork unitOfWork,
            IToggleEntityService toggleEntityService,
            IServiceRotaEntityService serviceRotaEntityService,
            IServiceRotaToggleEntityService serviceRotaToggleEntityService
            ) : base(unitOfWork)
        {            
            ToggleEntityService = toggleEntityService;
            ServiceRotaEntityService = serviceRotaEntityService;
            ServiceRotaToggleEntityService = serviceRotaToggleEntityService;
        }

        public bool Validate(string rota, string authorization)
        {
            var retorno = new HttpResult<IActionResult>();
            
            var serviceRotaToggle = ServiceRotaToggleEntityService.GetAll().Result.Where(x => x.Rota == rota).FirstOrDefault();

            var toggle = ToggleEntityService.Get(serviceRotaToggle.Toggle.Id);
                        
            var serviceRota = ServiceRotaEntityService.GetAll().Result.Where(x => x.Authorization == authorization).FirstOrDefault();

            //UnauthorizedMessageResponse request = new UnauthorizedMessageResponse();

            foreach (var toggleServiceRota in toggle.Result.ToggleServiceRotas)
            {
                if (toggleServiceRota.ServiceRota.Id == serviceRota.Id)
                    return true;
                else
                    return false;
            }


            return false;
        }

        //public async Task<HttpResult<List<Toggle>>> GetAll()
        //{
        //    var retorno = new HttpResult<List<Toggle>>();
        //    retorno.Response = new List<Toggle>();

        //    var retornotoggleGetAll = ToggleEntityService.GetAll();

        //    if (retornotoggleGetAll != null && retornotoggleGetAll.Result != null)
        //    {
        //        retorno.Response.AddRange(retornotoggleGetAll.Result);
        //    }
            
        //    retorno.SetHttpStatusToOk();

        //    return retorno;
        //}

        //public async Task<HttpResult<Toggle>> Get(int id)
        //{
        //    var retorno = new HttpResult<Toggle>();

        //    var retornoToggleGet = await ToggleEntityService.Get(id);

        //    if (retornoToggleGet == null) return retorno.SetHttpStatusToNotFound();

        //    retorno.Response = retornoToggleGet;
        //    retorno.SetHttpStatusToOk();

        //    return retorno;
        //}

        //public async Task<HttpResult<Toggle>> Update(int id, string description, bool flag)
        //{
        //    var retorno = new HttpResult<Toggle>();

        //    var retornoToggleGet = await ToggleEntityService.Get(id);

        //    if (retornoToggleGet == null) return retorno.SetHttpStatusToNotFound();

        //    retornoToggleGet.Description = description;
        //    retornoToggleGet.Flag = flag;

        //    _dbContext.SaveChanges();

        //    retorno.Response = retornoToggleGet;
        //    retorno.SetHttpStatusToOk();

        //    return retorno;
        //}

        //public async Task<HttpResult<Toggle>> Delete(int id)
        //{
        //    var retorno = new HttpResult<Toggle>();

        //    var retornoToggleGet = await ToggleEntityService.Get(id);

        //    if (retornoToggleGet == null) return retorno.SetHttpStatusToNotFound();

        //    retornoToggleGet.Active = false;

        //    _dbContext.SaveChanges();

        //    retorno.Response = retornoToggleGet;
        //    retorno.Set((HttpStatusCode)204, "Toggle delete");

        //    return retorno;
        //}
    }
}
