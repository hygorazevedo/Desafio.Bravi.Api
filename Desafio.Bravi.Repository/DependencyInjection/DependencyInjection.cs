using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Desafio.Bravi.Repository.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IObterClienteRepository, ClienteRepository>();
            services.AddScoped<IAdicionarClienteRepository, ClienteRepository>();
            services.AddScoped<IEditarClienteRepository, ClienteRepository>();
            services.AddScoped<IRemoverClienteRepository, ClienteRepository>();

            services.AddScoped<IMongoClient>(db => new MongoClient(""));

            return services;
        }
    }
}
