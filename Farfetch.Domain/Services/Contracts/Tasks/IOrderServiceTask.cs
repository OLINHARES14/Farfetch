using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;

namespace Farfetch.Domain.Services.Contracts.Tasks
{
    public interface IOrderServiceTask
    {
        HttpResult<Order> Register(Order order, string authorization, string rota);
    }
}
