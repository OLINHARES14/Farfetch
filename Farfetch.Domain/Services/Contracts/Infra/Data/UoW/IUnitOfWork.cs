using Farfetch.Domain.Services.Contracts.Infra.Data.Contexts;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW.Base;

namespace Farfetch.Domain.Services.Contracts.Infra.Data.UoW
{
    public interface IUnitOfWork : IUoWBase<IDbContextFarfetch>
    {

    }
}
