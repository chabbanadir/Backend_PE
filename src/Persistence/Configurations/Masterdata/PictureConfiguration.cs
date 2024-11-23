using Backend.Domain.Entities.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Masterdata;

public class PictureConfiguration : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> builder)
    {
        // throw new NotImplementedException();
        builder.Property(d => d.IsDeleted)
     .HasDefaultValue(false);

        builder.Property(b => b.Created)
        .HasDefaultValueSql("getdate()");

        builder.Property(b => b.Id)
        .HasDefaultValueSql("NEWSEQUENTIALID()");

    }
}
