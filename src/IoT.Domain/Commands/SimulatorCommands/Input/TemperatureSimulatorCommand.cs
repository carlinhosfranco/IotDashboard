using System;
using System.ComponentModel.DataAnnotations;

namespace IoT.Domain.Commands.SimulatorCommands.Input
{
    public class TemperatureSimulatorCommand
    {
        public int MaxIndexToSimulate { get; set; }
    }
}