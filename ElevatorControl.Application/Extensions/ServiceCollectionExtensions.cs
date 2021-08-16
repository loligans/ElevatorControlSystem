using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ElevatorControl.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddElevatorApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddScoped<IElevatorService, ElevatorService>();
            return serviceCollection;
        }
    }
}
