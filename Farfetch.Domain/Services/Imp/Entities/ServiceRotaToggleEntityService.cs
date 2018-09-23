using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Imp.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Imp.Entities
{
    public class ServiceRotaToggleEntityService : BaseService, IServiceRotaToggleEntityService
    {
        private IServiceRotaToggleRepository ServiceRotaToggleRepository { get;  }

        public ServiceRotaToggleEntityService(IUnitOfWork unitOfWork, IServiceRotaToggleRepository serviceRotaToggleRepository) : base(unitOfWork) { ServiceRotaToggleRepository = serviceRotaToggleRepository; }

        public async Task<List<ServiceRotaToggle>> GetAll() => await ServiceRotaToggleRepository.GetAll();

        public async Task<ServiceRotaToggle> Get(int id) => await ServiceRotaToggleRepository.Get(id);
    }
}
