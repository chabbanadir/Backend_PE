using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Masterdata;

public class InfoConfiguration : IEntityTypeConfiguration<Info>
{
    public void Configure(EntityTypeBuilder<Info> builder)
    {
        builder.HasOne(d => d.Oem)
               .WithMany(p => p.Infos)
                .HasForeignKey(d => d.FK_OemId);

        builder.HasOne(d => d.Harnessmaker)
               .WithMany(p => p.Infos)
               .HasForeignKey(d => d.FK_HarnessmakerId);

        builder.HasOne(d => d.Component)
             .WithMany(p => p.Infos)
               .HasForeignKey(d => d.FK_ComponentId);

        builder.HasOne(d => d.Cable)
           .WithMany(p => p.Infos)
             .HasForeignKey(d => d.FK_CableId);

    }
}