using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Utility
{
    public class NativeConfigurationManager
    {
        private readonly IConfiguration _config;
        private readonly string _projectDirectory;
        public NativeConfigurationManager(IConfiguration config)
        {
            var workingDirectory = Environment.CurrentDirectory;
            _projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            _config = config;
        }

        public string DB_BASE_URl => $"{_projectDirectory }{_config.GetSection("DbBase:Path").Value}\\";
    }
}
