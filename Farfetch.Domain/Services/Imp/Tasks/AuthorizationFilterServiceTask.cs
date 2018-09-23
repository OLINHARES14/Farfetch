using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Contracts.Tasks;
using Farfetch.Domain.Services.Imp.Entities.Base;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            
            foreach (var toggleServiceRota in toggle.Result.ToggleServiceRotas)
            {
                if (toggleServiceRota.ServiceRota.Id == serviceRota.Id)
                {
                    return true;
                }

                continue;
            }
            
            return false;
        }
    }
}
