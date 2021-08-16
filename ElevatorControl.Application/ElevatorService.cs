using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElevatorControl.Application.Models;
using Microsoft.Extensions.Logging;

namespace ElevatorControl.Application
{
    /// <inheritdoc cref="IElevatorService"/>
    internal class ElevatorService : IElevatorService
    {
        private readonly ILogger<ElevatorService> _logger;
        public ElevatorService(ILogger<ElevatorService> logger)
        {
            _logger = logger;
        }

        public Task AddFloorAsync(Floor floor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Floor>> GetServicingFloorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Floor> GetNextFloorAsync()
        {
            throw new NotImplementedException();
        }
    }
}
