using System;
using ElevatorControl.Application.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ElevatorControl.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddElevatorApplicationServices(this IServiceCollection serviceCollection, Action<ElevatorOptions> options)
        {
            serviceCollection.AddOptions();
            serviceCollection.Configure(options);

            serviceCollection.AddMemoryCache();
            serviceCollection.AddHostedService<Elevator>();
            serviceCollection.TryAddSingleton<IElevatorService, ElevatorService>();
            return serviceCollection;
        }
    }
}
