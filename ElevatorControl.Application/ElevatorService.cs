using System.Collections.Generic;
using System.Linq;
using ElevatorControl.Application.Models;
using ElevatorControl.Application.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ElevatorControl.Application
{
    /// <inheritdoc cref="IElevatorService"/>
    internal class ElevatorService : IElevatorService
    {
        private readonly ILogger<ElevatorService> _logger;

        private readonly object _elevatorQueueLock = new object();
        private readonly Queue<Floor> _elevatorQueue;
        private readonly HashSet<int> _floors;

        public ElevatorService(ILogger<ElevatorService> logger, IOptions<ElevatorOptions> options)
        {
            _logger = logger;
            _elevatorQueue = new Queue<Floor>();
            _floors = new HashSet<int>(options.Value.Floors);
        }

        public void AddFloor(Floor floor)
        {
            if (!_floors.Contains(floor.Number))
            {
                _logger.LogWarning($"Invalid floor number: {floor.Number}");
                return;
            }
            lock (_elevatorQueueLock)
            {
                _elevatorQueue.Enqueue(floor);
            }
        }

        public IEnumerable<Floor> GetServicingFloors()
        {
            lock (_elevatorQueueLock)
            {
                return _elevatorQueue.ToList();
            }
        }

        public Floor? GetNextFloor()
        {
            lock (_elevatorQueueLock)
            {
                return _elevatorQueue.Count == 0 ? null : _elevatorQueue.Peek();
            }
        }

        Floor? IElevatorService.RemoveNextFloor()
        {
            lock (_elevatorQueueLock)
            {
                return _elevatorQueue.Count == 0 ? null : _elevatorQueue.Dequeue();
            }
        }
    }
}
