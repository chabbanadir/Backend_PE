using Backend.Domain.Entities;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configurations.Masterdata;

public class ComponentPartConfiguration : IEntityTypeConfiguration<ComponentPart>
{
    public void Configure(EntityTypeBuilder<ComponentPart> builder)
    {
         builder.HasOne(pt => pt.Part)
         .WithMany(p => p.PartsOf) // <--
         .HasForeignKey(pt => pt.FK_PartId)
         .OnDelete(DeleteBehavior.Restrict); // see the note at the end

            builder.HasOne(pt => pt.Component)
            .WithMany(t => t.Parts)
            .HasForeignKey(pt => pt.FK_ComponentId);

        builder.HasQueryFilter(p => !p.IsDeleted);

        builder.Property(d => d.IsDeleted)
        .HasDefaultValue(false);

        builder.Property(b => b.Created)
        .HasDefaultValueSql("getdate()");

        builder.Property(b => b.Id)
        .HasDefaultValueSql("NEWSEQUENTIALID()");
    }
}
