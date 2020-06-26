using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientServer.Middleware;
using Microsoft.AspNetCore.Builder;

namespace ClientServer
{
    public static class RouteConfig
    {
        public static void BuildReverseProxy(IApplicationBuilder app)
        {
            app.UseReverseProxyMiddleware();
        }
    }
}
