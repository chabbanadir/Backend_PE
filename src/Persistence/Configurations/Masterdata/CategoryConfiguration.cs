using Backend.Domain.Entities;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Masterdata;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.HasOne(d => d.Picture)
           .WithMany(p => p.Categories)
           .HasForeignKey(d => d.FK_PictureId);

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
