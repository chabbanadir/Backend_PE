using Backend.Domain.Entities;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Masterdata;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200);

        builder.HasOne(d => d.Oem)
                   .WithMany(p => p.Components)
                   .HasForeignKey(d => d.FK_OemId)
                   .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(d => d.Category)
               .WithMany(p => p.Components)
                   .HasForeignKey(d => d.FK_CategoryId);


        builder.HasOne(d => d.Config)
               .WithMany(p => p.Components)
               .HasForeignKey(d => d.FK_ConfigId);    
        
        
/*        builder.HasOne(d => d.Cable)
               .WithMany(p => p.Components)
               .HasForeignKey(d => d.FK_CableId);
*/
        //
        /*        builder.HasMany(d => d.ComponentChilds)
                       .WithOne(p => p.component)
                       .HasForeignKey(d => d.FK_ParentComponentId);*/




        builder.HasOne(d => d.Picture)
       .WithMany(p => p.Components)
       .HasForeignKey(d => d.FK_PictureId)
       .OnDelete(DeleteBehavior.NoAction);


        builder.Property(d => d.IsDeleted)
     .HasDefaultValue(false);

        builder.Property(d => d.Status)
            .HasDefaultValue(Status.Active);

        builder.Property(b => b.Created)
.HasDefaultValueSql("getdate()");

        builder.Property(b => b.Id)
        .HasDefaultValueSql("NEWSEQUENTIALID()");

    }
}
