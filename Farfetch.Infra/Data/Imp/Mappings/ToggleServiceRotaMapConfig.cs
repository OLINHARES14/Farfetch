using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Farfetch.Domain.Models.Entities;
using System;
using Microsoft.EntityFrameworkCore;

namespace Farfetch.Infra.Data.Imp.Mappings
{
    internal static class ToggleServiceRotaMapConfig
    {
        internal static Action<EntityTypeBuilder<ToggleServiceRota>> ConfigureMap() => (entity) =>
        {
            entity.ToTable("ToggleServiceRota");

            entity.HasKey(it => it.Id);

            entity.Property(it => it.ToggleId)
            .HasColumnName("ToggleId")
            .IsRequired();

            entity.Property(it => it.ServiceRotaId)
            .HasColumnName("ServiceRotaId")
            .IsRequired();

            entity.HasOne(it => it.Toggle)
            .WithMany(it => it.ToggleServiceRotas)
            .HasForeignKey(it => it.ToggleId)
            .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(it => it.ServiceRota)
            .WithMany(it => it.ToggleServiceRotas)
            .HasForeignKey(it => it.ServiceRotaId)
            .OnDelete(DeleteBehavior.Cascade);
            
        };
    }
}
