using ApiApplication.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ApiApplication.Infrastructure;

public static class AuthenticationExtensions
{
    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddSingleton<ICustomAuthenticationTokenService, CustomAuthenticationTokenService>();
        services.AddAuthentication(options =>
        {
            options.AddScheme<CustomAuthenticationHandler>(CustomAuthenticationSchemeOptions.AuthenticationScheme, CustomAuthenticationSchemeOptions.AuthenticationScheme);
            options.RequireAuthenticatedSignIn = true;                
            options.DefaultScheme = CustomAuthenticationSchemeOptions.AuthenticationScheme;
        });
        return services;
    }

    public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}