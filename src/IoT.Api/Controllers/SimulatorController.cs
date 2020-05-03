using System;
using System.Threading.Tasks;
using IoT.Domain.Commands.SimulatorCommands.Input;
using IoT.Domain.Helper;
using IoT.Domain.SocketsManager;
using IoT.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IoT.Api.Controllers
{

    public class SimulatorController : ApplicationController
    {
        private readonly ITemperatureSocketManager _socketTemp;
        public SimulatorController(AppDbContext appDbContext,
                                    IoTDevicesSimulator iotSimulator,
                                    ITemperatureSocketManager socketTemp) : base(appDbContext, iotSimulator)
        {
            _socketTemp = socketTemp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/simulators/temperature/")]
        [HttpPost]
        public async Task<IActionResult> Temperature(TemperatureSimulatorCommand command)
        {
            await IotSimulator.TempGenerator(command.MaxIndexToSimulate);
            return View("Index");
        }
        
        // [Route("api/simulators/people/")]
        // [HttpPost]
        // public async Task<IActionResult> People(PeopleSimulatorCommand command)
        // {
        //     //await IotSimulator.TempGenerator(command.MaxIndexToSimulate);
        //     for (int i = 0; i < command.MaxIndexToSimulate; i++)
        //     {
        //         Console.WriteLine($"{i}");                
        //     }
        //     return View("Index");
        // }                
    }
}