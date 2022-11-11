using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace ApiApplication.Integrations.Imdb;

public static class ImdbRestApiExtensions
{
    public static IServiceCollection ConfigureImdbApiClient(this IServiceCollection services, IConfiguration configuration)
    {
        const string sectionName = "ApiApplication:Integrations:Imdb";
        services.Configure<ImdbOptions>(configuration.GetSection(sectionName));
        var integrationConfig = configuration.GetSection(sectionName).Get<ImdbOptions>();
        services
            .AddRefitClient<IImdbApi>(new RefitSettings(new NewtonsoftJsonContentSerializer()))
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(integrationConfig.BaseAddress));

        return services;
    }
}