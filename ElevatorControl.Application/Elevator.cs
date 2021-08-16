using System;
using System.Threading;
using System.Threading.Tasks;
using ElevatorControl.Application.Models;
using ElevatorControl.Application.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ElevatorControl.Application
{
    internal class Elevator : BackgroundService
    {
        private readonly ILogger<Elevator> _logger;
        private readonly ElevatorOptions _elevatorOptions;
        private readonly IElevatorService _elevatorService;
        public Elevator(
            ILogger<Elevator> logger,
            IOptions<ElevatorOptions> elevatorOptions,
            IElevatorService elevatorService)
        {
            _logger = logger;
            _elevatorOptions = elevatorOptions.Value;
            _elevatorService = elevatorService;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Turning on the elevator!");
            Floor? startingFloor = null;
            do
            {
                var destinationFloor = _elevatorService.RemoveNextFloor();
                if (destinationFloor is null || destinationFloor.Number == startingFloor?.Number)
                {
                    // No floors in the queue wait 100ms before trying again
                    await Task.Delay(100, cancellationToken);
                    continue;
                }

                // Simulate the elevator navigating to the next floor
                _logger.LogInformation($"Starting floor {startingFloor?.Number ?? 0}");
                var distance = Math.Abs((startingFloor?.Number ?? 0) - destinationFloor.Number);
                for (var i = 1; i <= distance; i++)
                {
                    await Task.Delay(_elevatorOptions.MillisPerFloor, cancellationToken);
                    _logger.LogInformation($"Arrived at floor {startingFloor?.Number ?? 0 + i}");
                }

                startingFloor = destinationFloor;
            } while (cancellationToken.IsCancellationRequested is false);
        }
    }
}
