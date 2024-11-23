using Backend.Domain.Entities;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Masterdata;

public class ConfigConfiguration : IEntityTypeConfiguration<Config>
{
    public void Configure(EntityTypeBuilder<Config> builder)
    {
        builder.HasOne(d => d.Oem)
               .WithMany(p => p.Configs)
               .HasForeignKey(d => d.FK_OemId)
               .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(d => d.Picture)
           .WithMany(p => p.Configurations)
           .HasForeignKey(d => d.FK_PictureId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Note)
            .WithMany(p => p.Configs)
            .HasForeignKey(d => d.FK_NoteId)
            .OnDelete(DeleteBehavior.Cascade);

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
