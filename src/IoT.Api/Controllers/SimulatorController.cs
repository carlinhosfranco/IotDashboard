using System;
using System.Threading.Tasks;
using IoT.Infra.Data;
using IoT.Infra.SocketsManagers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IoT.Api.Controllers
{
    public class SimulatorController : ApplicationController
    {
        private readonly TemperatureSocketManager _socketManager;
        public SimulatorController(AppDbContext appDbContext,TemperatureSocketManager socketManager) : base(appDbContext)
        {
            _socketManager = socketManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [Route("api/Report")]
        //public async Task Report(double liquidTemp)
        public async Task Report(double liquidTemp)
        {
            var reading = new
            {
                Date = DateTime.Now,
                LiquidTemp = liquidTemp
            };
            // return Ok(new 
            // {
            //     TimeStamp = reading.Date,
            //     Temperature = reading.LiquidTemp
            //     });        
    
            //await _socketManager.SendMessageToAllAsync(JsonConvert.SerializeObject(reading));
        }

        [Route("api/TempGenerator")]
        public async Task Generate()
        {
            var rnd = new Random();
    
            for(var i = 0; i < 100; i++)
            {   
                             
                await Report(rnd.Next(23, 35));
                await Task.Delay(5000);
            }
        }        
    }
}