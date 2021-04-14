using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Configuration
{
    public class IsIsciConfiguration : IEntityTypeConfiguration<IsIsci>
    {
        public void Configure(EntityTypeBuilder<IsIsci> builder)
        {
           builder.HasKey(e => new { e.IsciId, e.IsId });
            builder.HasOne(d => d.Is)
                .WithMany(p => p.IsIsci)
                .HasForeignKey(d => d.IsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Is_Isci_Is");

            builder.HasOne(d => d.Isci)
                .WithMany(p => p.IsIsci)
                .HasForeignKey(d => d.IsciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Is_Isci_Isci");
        }
    }
}
