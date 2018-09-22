using Microsoft.EntityFrameworkCore;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.UoW.Base;

namespace Farfetch.Domain.Services.Contracts.Infra.Data.Contexts
{
    public interface IDbContextFarfetch : IDbContext
    {
        DbSet<Toggle> Toggle { get; set; }
        DbSet<ServiceRota> ServiceRota { get; set; }
    }
}
