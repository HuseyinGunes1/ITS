using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Configuration
{
    public class IsConfiguration : IEntityTypeConfiguration<Is>
    {
        public void Configure(EntityTypeBuilder<Is> builder)
        {
            builder.HasKey(e => e.IsId)
                    .HasName("PK_Is");

            builder.Property(e => e.IsAdi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Tarih).HasColumnType("datetime").IsRequired();

            builder.HasOne(d => d.Grup)
                .WithMany(p => p.Is)
                .HasForeignKey(d => d.GrupId)
                .HasConstraintName("FK_Work_Grup");

            builder.HasOne(d => d.Isveren)
                .WithMany(p => p.Is)
                .HasForeignKey(d => d.IsverenId)
                .HasConstraintName("FK_Is_Isveren");
        }
    }
}
