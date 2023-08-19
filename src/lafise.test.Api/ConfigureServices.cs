using System.Reflection;
using Lafise.SEGMIntegration.Api.Filters;
using Lafise.SEGMIntegration.Api.Versioning;
using Lafise.SEGMIntegration.Application.Common.Interfaces;
using Lafise.SEGMIntegration.Infrastructure.Services.SEGMService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

namespace Lafise.SEGMIntegration.Api
{
    /// <summary>
    /// Class used to inject different services related to the API
    /// </summary>
    public static class ConfigureServices
    {
        /// <summary>
        /// Adds dependencies from presentation layer
        /// </summary>
        /// <param name="services">Dependencies from inner layers</param>
        /// <returns></returns>
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddHealthChecks();

            services.AddControllers(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
            });

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();
                opt.ErrorResponses = new ApiVersioningErrorResponseProvider();
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "LAFISE.SEGM API",
                    Description = "API set for SEGM integration."
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var XmlCommentsFilePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(XmlCommentsFilePath);
                options.EnableAnnotations();
            });

            services.ConfigureOptions<ConfigureSwaggerOptions>();
            services.AddHttpClient<ISEGMService, SEGMService>();
            return services;
        }
    }
}
