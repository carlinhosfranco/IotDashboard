using System;
using System.Net;
using System.Threading.Tasks;
using IoT.Domain.Commands.TemperatureCommands.Input;
using IoT.Domain.Entities;
using IoT.Domain.Repositories;
using IoT.Infra.Data;
using IoT.Infra.SocketsManagers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IoT.Api.Controllers
{
    public class TemperatureController : ApplicationController
    {
        private readonly ITemperatureRepository _temperatureRepository;
        private readonly TemperatureSocketManager _socketManager;

        public TemperatureController(AppDbContext appDbContext, TemperatureSocketManager socketManager,ITemperatureRepository temperatureRepository) : base(appDbContext, socketManager)
        {
            _temperatureRepository = temperatureRepository;
            _socketManager = socketManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        //[Route("api/Report")]
        public async Task Report(double liquidTemp)
        {
            var reading = new
            {
                Date = DateTime.Now,
                LiquidTemp = liquidTemp
            };
            
    
            await _socketManager.SendMessageToAllAsync(JsonConvert.SerializeObject(reading));
        }
        [Route("api/Generate")]
        public async Task Generate()
        {
            var rnd = new Random();
    
            for(var i = 0; i < 100; i++)
            {                
                await Report(rnd.Next(23, 35));
                await Task.Delay(5000);
            }
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