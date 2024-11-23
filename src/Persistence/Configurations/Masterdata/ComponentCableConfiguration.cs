using Backend.Domain.Entities;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations.Masterdata;

public class ComponentCableConfiguration : IEntityTypeConfiguration<ComponentCable>
{
    public void Configure(EntityTypeBuilder<ComponentCable> builder)
    {
        builder.HasOne(pt => pt.Component)
                .WithMany(p => p.Cables)
                .HasForeignKey(pt => pt.FK_ComponentId);

        builder.HasOne(pt => pt.Cable)
                .WithMany(t => t.Components)
                .HasForeignKey(pt => pt.FK_CableId);

        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}
