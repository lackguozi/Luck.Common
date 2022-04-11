using Luck.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luck.Module.Pay
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<PayService>();
        }
    }
}
