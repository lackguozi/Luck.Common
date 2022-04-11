using System.Reflection;

using Luck.Common;

namespace DIApiDemo
{
    public  static class ServiceCollectionExtensions
    {
        public static void AddCustomizedConfigurationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddModules(configuration);
            var servicesProvider = services.BuildServiceProvider();
            var initalizerServices = servicesProvider.GetServices<IModuleInitializer>();
            foreach(var service in initalizerServices)
            {
                service.ConfigurationServices(services,configuration);
            }
        }
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            var modules = configuration.GetSection("Modules").Get<List<ModuleInfo>>();
            foreach (var module in modules)
            {
                module.Assembly = Assembly.Load(new AssemblyName(module.Id));
                var moduleType = module.Assembly.GetTypes().FirstOrDefault(a => typeof(IModuleInitializer).IsAssignableFrom(a));
                if (moduleType != null && moduleType != typeof(IModuleInitializer))
                {
                    services.AddSingleton(typeof(IModuleInitializer), moduleType);
                }
            }
        }
    }
}
