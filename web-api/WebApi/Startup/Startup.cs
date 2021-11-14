using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Services;

[assembly: FunctionsStartup(typeof(WebApi.Startup.Startup))]

namespace WebApi.Startup
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IPersonService, InMemoryPersonService>();
        }
    }
}
