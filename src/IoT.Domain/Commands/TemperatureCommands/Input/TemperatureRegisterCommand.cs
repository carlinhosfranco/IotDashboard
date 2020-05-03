namespace IoT.Domain.Commands.TemperatureCommands.Input
{
    public class TemperatureRegisterCommand
    {
        public string Source { get; set; }
        public double Value { get; set; }
    }
}