using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luck.Common
{
    public interface IModuleInitializer
    {
        public void ConfigurationServices( IServiceCollection services,IConfiguration configuration);
    }
}