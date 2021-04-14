using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Configuration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<KullaniciRefreshToken>
    {
        public void Configure(EntityTypeBuilder<KullaniciRefreshToken> builder)
        {
            builder.HasKey(x => x.CavusId);
            builder.Property(x => x.RefreshToken).IsRequired();
        }
    }
}
