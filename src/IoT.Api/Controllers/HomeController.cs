using IoT.Domain.Helper;
using IoT.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IoT.Api.Controllers
{
    public class HomeController : ApplicationController
    {
        public HomeController(AppDbContext appDbContext, IoTDevicesSimulator iotSimulator) : base(appDbContext, iotSimulator)
        {
        }       
        public IActionResult Index()
        {
            return View();                        
        }
        public IActionResult Simulator()
        {
            return View();                        
        }
        /* public string Temperature()
        {
            return "View()";                        
        } */
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();            
        }

    }
}