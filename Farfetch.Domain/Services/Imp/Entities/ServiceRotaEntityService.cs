using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Imp.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Imp.Entities
{
    public class ServiceRotaEntityService : BaseService, IServiceRotaEntityService
    {
        private IServiceRotaRepository ServiceRotaRepository { get;  }

        public ServiceRotaEntityService(IUnitOfWork unitOfWork, IServiceRotaRepository serviceRotaRepository) : base(unitOfWork) { ServiceRotaRepository = serviceRotaRepository; }

        public async Task<List<ServiceRota>> GetAll() => await ServiceRotaRepository.GetAll();

        public async Task<ServiceRota> Get(int id) => await ServiceRotaRepository.Get(id);
    }
}
