using System.Threading.Tasks;
using ElevatorControl.Application;
using ElevatorControl.Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevatorControl.Tests
{
    [TestClass]
    public class ElevatorServiceTests
    {
        private readonly IElevatorService _elevatorService;

        public ElevatorServiceTests()
        {
            _elevatorService = new ElevatorService(null);
        }

        [TestMethod]
        public async Task AddFloorAsync_AddsCorrectFloor()
        {
            await _elevatorService.AddFloorAsync(new Floor() {Number = 1});
        }

        [TestMethod]
        public async Task GetServicingFloorsAsync_ReturnsCorrectFloors()
        {
            await _elevatorService.GetServicingFloorsAsync();
        }

        [TestMethod]
        public async Task GetNextFloorAsync_CorrectFloor()
        {
            await _elevatorService.GetNextFloorAsync();
        }
    }
}
