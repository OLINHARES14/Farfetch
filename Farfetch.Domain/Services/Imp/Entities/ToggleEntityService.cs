using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Imp.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Imp.Entities
{
    public class ToggleEntityService : BaseService, IToggleEntityService
    {
        private IToggleRepository ToggleRepository { get;  }

        public ToggleEntityService(IUnitOfWork unitOfWork, IToggleRepository toggleRepository) : base(unitOfWork) { ToggleRepository = toggleRepository; }

        public async Task<List<Toggle>> GetAll() => await ToggleRepository.GetAll();

        public async Task<Toggle> Get(int id) => await ToggleRepository.Get(id);
    }
}
