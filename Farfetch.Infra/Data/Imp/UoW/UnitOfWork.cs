using Farfetch.Domain.Services.Contracts.Infra.Data.Contexts;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW;
using Farfetch.Infra.Data.Imp.Contexts;
using Farfetch.Infra.Data.Imp.UoW.Base;

namespace Farfetch.Infra.Data.Imp.UoW
{
    public class UnitOfWork : UoWBase<IDbContextFarfetch>, IUnitOfWork
    {
        public UnitOfWork(DbContextFarfetch context)  : base(context)
        {
        }
    }
}
