using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Repositories;
using Farfetch.Infra.Data.Imp.Contexts;
using Farfetch.Infra.Data.Imp.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farfetch.Infra.Data.Imp.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContextFarfetch context) : base(context) { }

        public async Task<List<Order>> GetAll() => await Context.Order.ToListAsync();

        public async Task<Order> Get(int id) => await Context.Order.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}
