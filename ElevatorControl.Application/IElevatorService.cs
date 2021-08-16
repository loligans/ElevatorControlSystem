using System.Collections.Generic;
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
        public void AddFloor(Floor floor);

        /// <summary>
        /// Retrieves the list of floors the elevator is currently servicing
        /// </summary>
        public IEnumerable<Floor> GetServicingFloors();

        /// <summary>
        /// Gets the next floor that needs to be serviced
        /// </summary>
        public Floor? GetNextFloor();

        /// <summary>
        /// Removes the specified floor from the elevators queue
        /// </summary>
        internal Floor? RemoveNextFloor();
    }
}
