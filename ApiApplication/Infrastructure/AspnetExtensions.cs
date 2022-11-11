using System.Reflection;
using ApiApplication.Infrastructure.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ApiApplication.Infrastructure;

public static class AspnetExtensions
{
    public static IServiceCollection ConfigureAspnetApi(this IServiceCollection services)
    {
        services.AddControllers(options =>
            {
                //options.Filters.Add<ModelStateValidationFilter>();
                options.SuppressAsyncSuffixInActionNames = false;
            })
            .AddJsonOptions(options =>
            {
                
                // todo: snake case properties    
            });
        
        // configure mediatr 
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        // configure automapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        // add validator
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }

    public static IApplicationBuilder UseAspnetApi(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseHttpsRedirection();

        return app;
    }
}