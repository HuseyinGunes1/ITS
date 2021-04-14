using FluentValidation.AspNetCore;
using ITS.CORE.Entites;
using ITS.DATA.Context;
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
           
            //FluentValidation Serrvisini AddFluetValidation ile uygulamaya entegre edecez
            //Entitlere gelen validationlar�n nerde tututuldu�unu sisteme bildirmemiz laz�m 
            //RegisterValidatorsFromAssemblyContaining i�inde tan�mlad���m�z s�n�f neyse o s�n�f�n i�inde bulundu�u 
            //Asembly bulup o asembly i�erisindeki t�m validater lar� bulup sisteme entegre edicek
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionString"]);
            });
            services.AddIdentity<Cavus, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();


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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
