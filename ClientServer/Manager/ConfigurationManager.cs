using Microsoft.Extensions.Configuration;

namespace ClientServer.Manager
{
    public class ConfigurationManager
    {
        private readonly IConfiguration _config;
        public ConfigurationManager(IConfiguration config)
        {
            _config = config;
        }

        public string API_BASE_URl => _config.GetSection("ApiServer:BasePath").Value;
    }
}
