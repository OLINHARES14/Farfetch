using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Farfetch.Domain.Models.Entities;
using System;
using Microsoft.EntityFrameworkCore;

namespace Farfetch.Infra.Data.Imp.Mappings
{
    internal static class ServiceRotaMapConfig
    {
        internal static Action<EntityTypeBuilder<ServiceRota>> ConfigureMap() => (entity) =>
        {
            entity.Property(ti => ti.Rota)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasMany(it => it.ToggleServiceRotas)
                .WithOne(it => it.ServiceRota)
                .HasForeignKey(it => it.ServiceRotaId)
                .OnDelete(DeleteBehavior.Cascade);
            ;            
        };
    }
}
