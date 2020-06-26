using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientServer.Constants;
using ClientServer.Manager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClientServer.Extention
{
    public static class ServiceExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddSingleton(new ConfigurationManager(configuration));

            serviceCollection.AddHttpClient(CommonConstant.API_CLIENT, c => { });

            return serviceCollection;
        }
    }
}
