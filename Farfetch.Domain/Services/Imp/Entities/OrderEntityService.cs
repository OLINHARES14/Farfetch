using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Domain.Services.Imp.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Imp.Entities
{
    public class OrderEntityService : BaseService, IOrderEntityService
    {
        private IOrderRepository OrderRepository { get;  }

        public OrderEntityService(IUnitOfWork unitOfWork, IOrderRepository orderRepository) : base(unitOfWork) { OrderRepository = orderRepository; }

        public async Task<List<Order>> GetAll() => await OrderRepository.GetAll();

        public async Task<Order> Get(int id) => await OrderRepository.Get(id);
    }
}
