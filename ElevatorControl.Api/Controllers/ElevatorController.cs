using System.Collections.Generic;
using ElevatorControl.Application;
using ElevatorControl.Application.Models;
using ElevatorControl.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ElevatorControl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElevatorController : ControllerBase
    {
        private readonly ILogger<ElevatorController> _logger;
        private readonly IElevatorService _elevatorService;
        public ElevatorController(ILogger<ElevatorController> logger, IElevatorService elevatorService)
        {
            _logger = logger;
            _elevatorService = elevatorService;
        }

        /// <summary>
        /// Adds a floor to the elevators queue
        /// </summary>
        /// <param name="floor">The floor to add</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("floors")]
        public IActionResult AddFloorAsync([FromBody]ElevatorFloorRequest floor)
        {
            _logger.LogDebug("Adding floor {number} to elevator queue", floor);
            _elevatorService.AddFloor(new Floor() {Number = floor.Number});
            return Ok();
        }

        /// <summary>
        /// Retrieves the list of floors the elevator is currently servicing
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("floors")]
        public ActionResult<IEnumerable<Floor>> GetServicingFloorsAsync()
        {
            _logger.LogDebug("Retrieving floors being serviced by the elevator");
            var floors = _elevatorService.GetServicingFloors();
            return Ok(floors);
        }

        /// <summary>
        /// Gets the next floor that needs to be serviced
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("floors/next")]
        public ActionResult<Floor> GetNextFloorAsync()
        {
            _logger.LogDebug("Retrieving the next floor being serviced by the elevator");
            var nextFloor = _elevatorService.GetNextFloor();
            return Ok(nextFloor);
        }
    }
}
