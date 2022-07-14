
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoFinanceiro.Infrastructure.Repositories;
using ProjetoFinanceiro.Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjetoFinanceiro.Testes.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            IConfiguration configuration = GetConfiguration();
            services.AddSingleton<IConfiguration>(configuration);
            RegisterDependencies(services);

            return services;
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<AppTestePrincipal>();

            //repositorios
            services.AddScoped<IClienteRepository, ClienteRepository>();

            //servicos
            services.AddScoped<ClienteService>();

            //teste
            services.AddScoped<RepositorioTeste>();

            services.AddScoped<ServicoTeste>();




        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            return configuration;
        }
    }
}

