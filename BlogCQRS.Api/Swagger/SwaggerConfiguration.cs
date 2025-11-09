using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BlogCQRS.Api.Swagger
{
    public class SwaggerConfiguration : IConfigureOptions<SwaggerGenOptions>
    {
        public readonly IApiVersionDescriptionProvider _provider;

        public SwaggerConfiguration(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Function to configure swagger options
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            foreach ( var desciption in _provider.ApiVersionDescriptions )
            {
                options.SwaggerDoc(desciption.GroupName, CreateVersionInfo(desciption));
            } 
        }

        /// <summary>
        /// Function to create a version information of type "OpenApiInfo"
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var versionInfo = new OpenApiInfo
            {
                Title = "API",
                Version = description.ApiVersion.ToString()
            };

            if ( description.IsDeprecated )
            {
                versionInfo.Description = "The version has been deprecated.";
            }

            return versionInfo;
        }
    }
}
