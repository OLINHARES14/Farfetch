using Microsoft.EntityFrameworkCore;
using Farfetch.Domain.Models.Entities;
using Farfetch.Domain.Services.Contracts.Infra.Data.Contexts;
using Farfetch.Infra.Data.Imp.Mappings;

namespace Farfetch.Infra.Data.Imp.Contexts
{
    public class DbContextFarfetch : DbContext, IDbContextFarfetch
    {
        public DbContextFarfetch(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Toggle> Toggle { get; set; }
        public DbSet<ServiceRota> ServiceRota { get; set; }
        public DbSet<ServiceRotaToggle> ServiceRotaToggle { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity(ToggleMapConfig.ConfigureMap());
        }
    }
}
