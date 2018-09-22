using System;

namespace Farfetch.Domain.Services.Contracts.Infra.Data.UoW.Base
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
    }
}
