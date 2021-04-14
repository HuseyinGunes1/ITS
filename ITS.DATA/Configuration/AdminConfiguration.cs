using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITS.DATA.Configuration
{
    //DbContext sınıfı dışında başka bir sınıfta entity lerimi configure edebilmem için o sınıf içinde IEntityTypeConfiguration interface sini implemente etmem gerekiyor
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admin");//veritabanında tablo ismine karşılık gelir
            builder.HasKey(x => x.AdminId);
            builder.Property(x => x.AdminAdi)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
