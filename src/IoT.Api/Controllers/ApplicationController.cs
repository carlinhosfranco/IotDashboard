using System.Threading.Tasks;
using IoT.Domain.Helper;
using IoT.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IoT.Api.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly AppDbContext _dbContext;
        protected readonly IoTDevicesSimulator IotSimulator; //Helpr that simulate the iot devices
        private bool _willCommit;

        protected ApplicationController(AppDbContext appDbContext, IoTDevicesSimulator iotSimulator)
        {
            _dbContext = appDbContext;
            IotSimulator = iotSimulator;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) 
        {
            var executedContext = await next.Invoke();
            if (executedContext.Exception == null && ModelState.ErrorCount == 0 && _willCommit)
            {
                await _dbContext.SaveChangesAsync();
                
            }
        }
        protected virtual void Commit()
        {
            _willCommit = true;
        }        
    }
}