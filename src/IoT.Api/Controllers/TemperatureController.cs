using System;
using System.Threading.Tasks;
using IoT.Domain.Commands.TemperatureCommands.Input;
using IoT.Domain.Entities;
using IoT.Domain.Helper;
using IoT.Domain.Repositories;
using IoT.Domain.SocketsManager;
using IoT.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IoT.Api.Controllers
{
    public class TemperatureController : ApplicationController
    {
        private readonly ITemperatureRepository _temperatureRepository;
        private readonly ITemperatureSocketManager _socketTemp;

        public TemperatureController(AppDbContext appDbContext,
                                    IoTDevicesSimulator iotSimulator,
                                    ITemperatureSocketManager socketTemp, 
                                    ITemperatureRepository temperatureRepository) : base(appDbContext, iotSimulator)
        {
            _temperatureRepository = temperatureRepository;
            _socketTemp = socketTemp;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [Route("api/temperatures/")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var tempList = await _temperatureRepository.GetAllTemperatures();
            
            return Ok(tempList);
        }

        [HttpPost]
        [Route("api/temperatures/")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(TemperatureRegisterCommand command)
        {
            var temp = new Temperature
            {
                Id = Guid.NewGuid(),
                Source = command.Source,
                Value = command.Value                                
            };

            await _temperatureRepository.SaveTemperature(temp);

            Commit();
            
            return Ok();

        }
    }
}