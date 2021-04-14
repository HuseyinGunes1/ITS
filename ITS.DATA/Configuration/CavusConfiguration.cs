using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Configuration
{
    public class CavusConfiguration : IEntityTypeConfiguration<Cavus>
    {
        public void Configure(EntityTypeBuilder<Cavus> builder)
        {
           

            builder.HasIndex(e => e.GrupId)
                .HasName("IX_Cavus")
                .IsUnique();

            
               
            builder.HasOne(d => d.Grup)
                .WithOne(p => p.Cavus)
                .HasForeignKey<Cavus>(d => d.GrupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cavus_Grup");
        }
    }
}
