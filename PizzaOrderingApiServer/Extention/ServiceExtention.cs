using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Respository;
using DomainResource;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utility;

namespace PizzaOrderingApiServer.Extention
{
    public static class ServiceExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // tiny mapper bindings.
            MapHelper.Map();


            var config = new NativeConfigurationManager(configuration);
            serviceCollection.AddSingleton(config);

            serviceCollection.AddTransient<DataContext>(s => new DataContext(config.DB_BASE_URl));

            return serviceCollection;
        }
    }
}
