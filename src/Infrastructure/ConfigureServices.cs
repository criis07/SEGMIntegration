using lafise.test.Application.Common.Interfaces;
using lafise.test.Infrastructure.Services;
using lafise.test.Infrastructure.Services.SEGMService;
using LAFISE.CrossCutting.Core.Interfaces;
using LAFISE.CrossCutting.Infrastructure.Common;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITodoService, TodoService>();
            services.AddHttpClient<ISEGMService, SEGMService>();
            return services;
        }
    }
}
