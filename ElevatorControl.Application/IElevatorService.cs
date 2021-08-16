using System.Collections.Generic;
using System.Threading.Tasks;
using ElevatorControl.Application.Models;

namespace ElevatorControl.Application
{
    /// <summary>
    /// The elevator service contract
    /// </summary>
    public interface IElevatorService
    {
        /// <summary>
        /// Adds a floor to the elevators queue
        /// </summary>
        public Task AddFloorAsync(Floor floor);
        /// <summary>
        /// Retrieves the list of floors the elevator is currently servicing
        /// </summary>
        public Task<IEnumerable<Floor>> GetServicingFloorsAsync();
        /// <summary>
        /// Gets the next floor that needs to be serviced
        /// </summary>
        public Task<Floor> GetNextFloorAsync();
    }
}
