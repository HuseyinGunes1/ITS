using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Configuration
{
    public class GiderConfiguration : IEntityTypeConfiguration<Gider>
    {
        public void Configure(EntityTypeBuilder<Gider> builder)
        {
            builder.Property(e => e.GiderAciklama)
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      ;

            builder.Property(e => e.GiderKisi)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.GiderTarih).HasColumnType("datetime");

            builder.Property(e => e.GiderTutar).HasColumnType("decimal(18, 0)");

           builder.HasOne(d => d.Isci)
                .WithMany(p => p.Gider)
                .HasForeignKey(d => d.IsciId)
                .HasConstraintName("FK_Gider_Isci");
        }
    }
}
