using Backend.Domain.Entities.DrawingGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.DrawingGenerator;

public class PartNumberConfiguration : IEntityTypeConfiguration<PartNumber>
{
    public void Configure(EntityTypeBuilder<PartNumber> builder)
    {
        builder.HasOne(d => d.Oem)
               .WithMany(p => p.PartNumbers)
                .HasForeignKey(d => d.FK_OemId);
        
        builder.HasOne(d => d.Harnessmaker)
               .WithMany(p => p.PartNumbers)
               .HasForeignKey(d => d.FK_HarnessmakerId);
    }
}
