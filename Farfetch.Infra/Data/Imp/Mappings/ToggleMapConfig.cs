using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Farfetch.Domain.Models.Entities;
using System;

namespace Farfetch.Infra.Data.Imp.Mappings
{
    internal static class ToggleMapConfig
    {
        internal static Action<EntityTypeBuilder<Toggle>> ConfigureMap() => (entity) =>
        {
            entity.Property(ti => ti.Description)
            .IsRequired()
            .HasMaxLength(100)            
            ;            
        };
    }
}
