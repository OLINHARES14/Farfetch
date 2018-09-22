using Farfetch.Domain.HttpServices;
using Farfetch.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Tasks
{
    public interface IOrderServiceTask
    {
        HttpResult<Order> Register(Order order);        
    }
}
