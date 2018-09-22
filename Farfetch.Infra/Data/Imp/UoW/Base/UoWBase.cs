using Farfetch.Domain.Services.Contracts.Infra.Data.UoW.Base;
using System;

namespace Farfetch.Infra.Data.Imp.UoW.Base
{
    public abstract class UoWBase<TContext> : IUoWBase<TContext> where TContext : IDbContext
    {
        private bool disposed = false;
        public TContext Context { get; }

        public UoWBase(TContext context) => Context = context;

        public virtual void SaveChanges() => Context.SaveChanges();

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                Context.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
