using System.Text.Json.Serialization;
using Lafise.SEGMIntegration.Application;
using Lafise.SEGMIntegration.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Yoh.Text.Json.NamingPolicies;

namespace Lafise.SEGMIntegration.Api
{
    /// <summary>
    /// Class with different configurations and dependency injection of components of the API
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Dependency injection constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// IConfiguration to access appsettings settings
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiServices();
            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc(opts =>
            {
                opts.Filters.Add(new AllowAnonymousFilter());
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicies.SnakeCaseLower;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            })
            .AddXmlSerializerFormatters();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="provider"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseHealthChecks("/health");

            app.UseSwagger(settings =>
            {
                settings.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(settings =>
            {
                foreach (var description in provider.ApiVersionDescriptions.Select(des => des.GroupName)
                    .Where(des => des is not null))
                {
                    settings.SwaggerEndpoint(
                        $"{description}/swagger.json",
                        description.ToUpperInvariant());
                }
                settings.RoutePrefix = "swagger";
            });

            app.UseRouting();

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseXRay("Lafise.SEGMIntegration");

            app.UseEndpoints(endpoints =>
            {
                if (env.IsDevelopment())
                {
                    endpoints.MapControllers().WithMetadata(new AllowAnonymousAttribute());
                }
                else
                {
                    endpoints.MapControllers();
                }
            });
        }
    }
}
