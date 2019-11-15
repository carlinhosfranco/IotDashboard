using System.Collections.Generic;
using IoT.Infra.Data;
using IoT.Infra.SocketsManagers;
using Microsoft.AspNetCore.Mvc;

namespace IoT.Api.Controllers
{
    //[Route("api/[controller]/{Action}")]
    public class HomeController : ApplicationController
    {
        public HomeController(AppDbContext appDbContext) : base(appDbContext)
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
        public string Temperature()
        {
            return "View()";                        
        }
        //public IActionResult About()
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