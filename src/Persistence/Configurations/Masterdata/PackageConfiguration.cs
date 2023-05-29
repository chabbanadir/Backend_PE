using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Masterdata;

public class PackageConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {
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
