using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Configuration
{
    public class IsverenConfiguration : IEntityTypeConfiguration<Isveren>
    {
        public void Configure(EntityTypeBuilder<Isveren> builder)
        {
            builder.Property(e => e.IsverenAdi)
                      .HasMaxLength(50)
                      .IsUnicode(false);

            builder.Property(e => e.IsverenSoyadi)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
