using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Configuration
{
    public class GrupConfiguration : IEntityTypeConfiguration<Grup>
    {
        public void Configure(EntityTypeBuilder<Grup> builder)
        {
            builder.Property(e => e.GrupAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();
        }
    }
}
