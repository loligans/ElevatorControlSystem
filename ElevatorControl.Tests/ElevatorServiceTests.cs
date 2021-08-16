using System.Linq;
using ElevatorControl.Application;
using ElevatorControl.Application.Models;
using ElevatorControl.Application.Options;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevatorControl.Tests
{
    [TestClass]
    public class ElevatorServiceTests
    {
        private readonly IElevatorService _elevatorService;

        public ElevatorServiceTests()
        {
            var options = new ElevatorOptions()
            {
                Floors = new []{ 0, 1, 2, 3, 4 }
            };
            _elevatorService = new ElevatorService(new NullLogger<ElevatorService>(), new OptionsWrapper<ElevatorOptions>(options));
        }

        [TestMethod]
        public void AddFloorAsync_AddsCorrectFloor()
        {
            _elevatorService.AddFloor(new Floor() {Number = 1});
            _elevatorService.AddFloor(new Floor() {Number = 3});
            var firstFloor = _elevatorService.RemoveNextFloor();
            var secondFloor = _elevatorService.RemoveNextFloor();

            Assert.IsTrue(firstFloor?.Number == 1);
            Assert.IsTrue(secondFloor?.Number == 3);
        }

        [TestMethod]
        public void GetServicingFloorsAsync_ReturnsCorrectFloors()
        {
            _elevatorService.AddFloor(new Floor() {Number = 1});
            _elevatorService.AddFloor(new Floor() {Number = 3});
            var elements = _elevatorService.GetServicingFloors();

            Assert.IsTrue(elements.Count() == 2);
        }

        [TestMethod]
        public void GetNextFloorAsync_ReturnsCorrectFloor()
        {
            _elevatorService.AddFloor(new Floor() {Number = 1});
            _elevatorService.AddFloor(new Floor() {Number = 3});

            var nextFloor1 = _elevatorService.GetNextFloor();
            var nextFloor2 = _elevatorService.GetNextFloor();
            Assert.IsTrue(nextFloor1 == nextFloor2);
        }
    }
}
