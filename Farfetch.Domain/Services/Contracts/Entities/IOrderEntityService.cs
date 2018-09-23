using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Entities
{
    public interface IOrderEntityService
    {
        Task<List<Order>> GetAll();
        Task<Order> Get(int id);
    }
}
