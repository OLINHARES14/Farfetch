using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farfetch.Domain.Services.Contracts.Infra.Data.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
    }
}
