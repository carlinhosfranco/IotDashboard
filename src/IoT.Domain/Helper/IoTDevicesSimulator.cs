using System;
using System.Threading.Tasks;
using IoT.Domain.Entities;
using IoT.Domain.SocketsManager;
using Newtonsoft.Json;

namespace IoT.Domain.Helper
{
    public class IoTDevicesSimulator
    {
        private readonly ITemperatureSocketManager _socketTemp;

        public IoTDevicesSimulator(ITemperatureSocketManager socketTemp)
        {
            _socketTemp = socketTemp;
        }

        private Temperature Report(double liquidTemp)
        {
            return new Temperature
            {
                CreateDate = DateTime.Now,
                Value = liquidTemp
            };
        }
        public async Task TempGenerator(int maxIndex)
        {
            var rnd = new Random();
    
            for(var i = 0; i < maxIndex; i++)
            {                
                var reading = Report(rnd.Next(23, 35));
                await _socketTemp.SendMessageToAllAsync(JsonConvert.SerializeObject(reading));                
                await Task.Delay(5000);
            }

        }
    }
}