using System;

namespace Farfetch.Domain.Services.Contracts.Infra.Data.UoW.Base
{
    public interface IUoWBase<TContext> : IDisposable where TContext : IDbContext
    {
        TContext Context { get; }
        void SaveChanges();
    }
}
