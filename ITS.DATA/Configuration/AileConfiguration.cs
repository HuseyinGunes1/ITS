using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Configuration
{
    public class AileConfiguration : IEntityTypeConfiguration<Aile>
    {
        public void Configure(EntityTypeBuilder<Aile> builder)
        {
            builder.HasKey(e => e.AileId);
            builder.Property(e => e.AileAdi)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);

            builder.HasOne(d => d.Grup)
                .WithMany(e => e.Aile)
                .HasForeignKey(d => d.GrupId)
                 .HasConstraintName("FK_Aile_Grup1");


        }
    }
}
