namespace IslamicFace.Presentation.API.DependencyInjections;

public static class DependencyInjection
{
    public static IServiceCollection AddApiLayerServices(this IServiceCollection services)
    {
        #region register Fluent validation & MediatR
        services.AddValidatorsFromAssembly(typeof(Application.Messaging.IBaseCommand).Assembly);
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Application.Messaging.IBaseCommand).Assembly));
        #endregion

        services.AddScoped(typeof(IBasRepository<,>) , typeof(BasRepository<,>));
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}

