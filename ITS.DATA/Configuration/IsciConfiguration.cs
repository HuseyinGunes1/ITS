using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Configuration
{
    public class IsciConfiguration : IEntityTypeConfiguration<Isci>
    {
        public void Configure(EntityTypeBuilder<Isci> builder)
        {
            builder.HasKey(e => e.IsciId)
                    .HasName("PK_Isci_1");

            builder.HasIndex(e => e.GrupId)
                .HasName("IX_Isci");

            builder.Property(e => e.IsciAdi)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.IsciSoyadi)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.Aile)
                .WithMany(p => p.Isci)
                .HasForeignKey(d => d.AileId)
                .HasConstraintName("FK_Isci_Aile");

           builder.HasOne(d => d.Grup)
                .WithMany(p => p.Isci)
                .HasForeignKey(d => d.GrupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Isci_Grup");
        }
    }
}
