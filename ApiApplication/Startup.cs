using ApiApplication.Apis.Showtimes.Factories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiApplication.Infrastructure;
using ApiApplication.Integrations.Imdb;

namespace ApiApplication;

public class Startup
{
    public Startup(IConfiguration configuration) 
        => Configuration = configuration;

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) =>
        services
            .ConfigureAspnetApi()
            .ConfigureAuthentication()
            .ConfigureDatabase()
            .ConfigureSwagger()
            .ConfigureImdbApiClient(Configuration)
            .AddScoped<IShowtimeFactory, ShowtimeFactory>();

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
        app
            .UseMiddleware<ErrorHandlerMiddleware>()
            .UseAspnetApi(env)
            .UseCustomAuthentication()
            .UseCustomwagger()
            .UseSampleData();
}