using Lafise.SEGMIntegration.Application.Common.Interfaces;
using Lafise.SEGMIntegration.Infrastructure.Services;
using Lafise.SEGMIntegration.Infrastructure.Services.SEGMService;
using LAFISE.CrossCutting.Core.Interfaces;
using LAFISE.CrossCutting.Infrastructure.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lafise.SEGMIntegration.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ISEGMService, SEGMService>();
            return services;
        }
    }
}
