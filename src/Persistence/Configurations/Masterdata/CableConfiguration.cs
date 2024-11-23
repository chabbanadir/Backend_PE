using Backend.Domain.Entities;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Masterdata;

public class CableConfiguration : IEntityTypeConfiguration<Cable>
{
    public void Configure(EntityTypeBuilder<Cable> builder)
    {
        builder.HasOne(d => d.Oem)
           .WithMany(p => p.Cables)
           .HasForeignKey(d => d.FK_OemId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Property(d => d.IsDeleted)
     .HasDefaultValue(false);

        builder.Property(d => d.Status)
            .HasDefaultValue(Status.Active);


        builder.Property(b => b.Created)
        .HasDefaultValueSql("getdate()"); 
        
        builder.Property(b => b.Id)
        .HasDefaultValueSql("NEWSEQUENTIALID()");

        /*        builder.Property(d => d.Id)
                .HasDefaultValue(new Guid());*/
    }
}
