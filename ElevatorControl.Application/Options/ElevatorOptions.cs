using System;
using System.Collections.Generic;

namespace ElevatorControl.Application.Options
{
    public class ElevatorOptions
    {
        /// <summary>
        /// The floors of the elevator
        /// </summary>
        public IEnumerable<int> Floors { get; set; } = Array.Empty<int>();
        /// <summary>
        /// The time it takes to go between floors
        /// </summary>
        public int MillisPerFloor { get; set; } = 1000;
    }
}
