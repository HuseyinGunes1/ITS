using FluentValidation.AspNetCore;
using ITS.CORE.Entites;
using ITS.CORE.Services;
using ITS.DATA.Context;
using ITS.Shared;
using ITS.SERVÝCE;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.SERVÝCE.Service;
using ITS.CORE.Repository;
using ITS.DATA.Implementasyon;
using ITS.CORE.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ITS.SERVÝCE.Security;

namespace IsciTakipSistemi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IIsciService, IsciService>();
            services.AddScoped<IAileService, AileService>();
            services.AddScoped<IGiderService, GiderService>();
            services.AddScoped<IIsIsciService, IsIsciService>();
            services.AddScoped(typeof(ISumService<,>), typeof(SumService<,>));
            services.AddScoped<IIsService, IsService>();
            services.AddScoped<IIsverenService, IsverenService>();
            services.AddScoped<ITokenService, CustomTokenService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IServiceGeneric<,>), typeof(ServicesGeneric<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //FluentValidation Serrvisini AddFluetValidation ile uygulamaya entegre edecez
            //Entitlere gelen validationlarýn nerde tututulduðunu sisteme bildirmemiz lazým 
            //RegisterValidatorsFromAssemblyContaining içinde tanýmladýðýmýz sýnýf neyse o sýnýfýn içinde bulunduðu 
            //Asembly bulup o asembly içerisindeki tüm validater larý bulup sisteme entegre edicek
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("ITS.DATA");
                });
            });
            services.AddIdentity<Cavus, IdentityRole>(opt=> {

                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireDigit = false;

            
            }
                ).AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CustomTokenOptions>(Configuration.GetSection("TokenAyar"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
            {
                var tokenOptionss = Configuration.GetSection("TokenAyar").Get<CustomTokenOptions>();
                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = tokenOptionss.Issuer,
                    ValidAudience = tokenOptionss.Audience[0],
                    IssuerSigningKey = CustomSecurity.GetSymetricSecurityKey(tokenOptionss.SecuritKey),

                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ClockSkew = TimeSpan.Zero


                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
