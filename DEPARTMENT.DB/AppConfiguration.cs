using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPARTMENT.DB
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();

            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            configBuilder.AddJsonFile(path, false);

            var root = configBuilder.Build();

            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");

            ConnectionString = appSetting.Value;

            
        }
        public string ConnectionString { get; set; }

    }

}
