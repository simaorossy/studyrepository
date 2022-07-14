using Microsoft.Extensions.DependencyInjection;
using ProjetoFinanceiro.Testes.Extensions;
using System;

namespace ProjetoFinanceiro.Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceColletion = ConfigureServices();
                IServiceProvider serviceProvider = serviceColletion.BuildServiceProvider();
                var eventServices = serviceProvider.GetRequiredService<AppTestePrincipal>();
                eventServices.Execute();
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }       

        static IServiceCollection ConfigureServices()
        {
            IServiceCollection serviceColletion = new ServiceCollection();
            serviceColletion.AddDependencies();
            return serviceColletion;
        }
    }
}
