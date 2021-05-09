using ITS.CORE.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Configuration
{
	class ÜcretConfiguration : IEntityTypeConfiguration<Ücret>
	{
		public void Configure(EntityTypeBuilder<Ücret> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.IsUcreti)
				.IsRequired();
				
		}
	}
}
