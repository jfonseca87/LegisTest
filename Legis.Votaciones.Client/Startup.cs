using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Legis.Votaciones.Business.Implementations;
using Legis.Votaciones.Business.Interfaces;
using Legis.Votaciones.Repository.Interfaces;
using Legis.Votaciones.Repository.SqlImplementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Legis.Votaciones.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VotacionesdbContext>(options => options.UseSqlServer(Configuration["SqlConn"]));

            services.AddControllersWithViews();

            //Repository DI Container
            services.AddTransient<ICandidatoRepository, CandidatoRepository>();
            services.AddTransient<IVotacionRepository, VotacionRepository>();

            //Business DI Container
            services.AddTransient<ICandidatoBusiness, CandidatoBusiness>();
            services.AddTransient<IVotacionBusiness, VotacionBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
