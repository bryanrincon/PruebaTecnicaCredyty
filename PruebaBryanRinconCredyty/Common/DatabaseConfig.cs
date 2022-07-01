using Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DatabaseConfig : IDatabaseConfig
    {
        private readonly IConfiguration _config;

        public DatabaseConfig(IConfiguration config)
        {
            _config = config;
        }

        public string ConnectionString { get => _config.GetConnectionString("LocalDB"); }
    }
}
