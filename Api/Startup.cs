using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Infra.CrossCutting.IoC;
using Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAppServiceCliente
            appServiceCliente, IAppServiceProduto appServiceProduto)
        {
            appServiceCliente.AddRange(Application.DataGenerator.getClientes()).ConfigureAwait(false);
            appServiceProduto.AddRange(Application.DataGenerator.getProdutos()).ConfigureAwait(false);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoApi V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Demo"));

            // var cnx = Configuration["SqlConnection:DB"];
            // services.AddDbContext<Infra.Data.Context.DataContext>(
            //     opt => opt.UseSqlServer(cnx));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                                new OpenApiInfo
                                {
                                    Title = "DemoAPI",
                                    Version = "v1"
                                });
            });

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}