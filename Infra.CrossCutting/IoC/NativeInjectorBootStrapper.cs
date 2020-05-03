using Application;
using Application.Interfaces;
using Application.Mapper;
using AutoMapper;
using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Service;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Automapper
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddScoped<DbContext, Infra.Data.Context.DataContext>();

            //application
            services.TryAddScoped<IAppServiceCliente, ClienteApplicationService>();
            services.TryAddScoped<IAppServiceProduto, ProdutoApplicationService>();

            //service
            services.TryAddScoped<IProdutoService, ProdutoService>();
            services.TryAddScoped<IClienteService, ClienteService>();

            //repository
            services.TryAddScoped<IClienteRepository, ClienteRepository>();
            services.TryAddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}