
namespace ElevatorControl.Contract
{
    /// <summary>
    /// The request model for taking an elevator to a floor
    /// </summary>
    public class ElevatorFloorRequest
    {
        /// <summary>
        /// The floor number to navigate to
        /// </summary>
        public int Number { get; set; }
    }
}
