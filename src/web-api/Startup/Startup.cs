using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Services;

// This is required to hook into the startup process
[assembly: FunctionsStartup(typeof(WebApi.Startup.Startup))]
namespace WebApi.Startup
{
    public class Startup : FunctionsStartup
    {
        /// <summary>
        /// Implementation of abstract function on the inherited "FunctionStartup" abstract class.
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Register all dependencies with their appropriate lifetimes
            builder.Services.AddSingleton<IPersonService, InMemoryPersonService>();
        }
    }
}
