using IslamicFace.Application.Abstractions.IServices.IdentityServices;
using IslamicFace.Application.Behaviors;
using IslamicFace.Domain.Abstractions.IServices;
using IslamicFace.Infrastructure.Services.EmailServices;
using IslamicFace.Infrastructure.Services.IdentityServices;
using MediatR;

namespace IslamicFace.Presentation.API.Extensions;

public static class DependencyInjection 
{
    public static IServiceCollection AddApiLayerServices(this IServiceCollection services)
    {
        #region register Fluent validation & MediatR
        //services.AddValidatorsFromAssembly(typeof(Application.Messaging.IBaseCommand).Assembly);
        //services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Application.Messaging.IBaseCommand).Assembly));
        #endregion

        services.AddMediatR(cfg =>
       cfg.RegisterServicesFromAssembly(typeof(IAppUserService).Assembly));

        // FluentValidation
        services.AddValidatorsFromAssembly(typeof(IAppUserService).Assembly);

        // Pipeline Behavior
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        
        

        services.AddScoped(typeof(IBasRepository<,>) , typeof(BasRepository<,>));
        services.AddScoped<IAppUserService, AppUserService>();
        services.AddScoped<IEmailService,EmailService>();
        return services;
    }
}

