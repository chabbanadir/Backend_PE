using Backend.Domain.Entities;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Masterdata;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        /*builder.HasOne(d => d.Config)
       .WithMany(p => p.Notes)
       .HasForeignKey(d => d.FK_ConfigId);*/

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
