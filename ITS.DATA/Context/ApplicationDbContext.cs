using ITS.CORE.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.DATA.Context
{
   public class ApplicationDbContext:IdentityDbContext<Cavus,IdentityRole,string>
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Aile> Aile { get; set; }
        public DbSet<Gider> Gider { get; set; }
        public DbSet<Grup> Grup { get; set; }
        public DbSet<Is> Is { get; set; }
        public DbSet<Isci> Isci { get; set; }
        public DbSet<IsIsci> IsIsci { get; set; }
        public DbSet<Isveren> Isveren { get; set; }
        public DbSet<Ücret> Ucret { get; set; }
        public DbSet<KullaniciRefreshToken> KullaniciRefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);

        }


    }
}
