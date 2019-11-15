using System;
using System.Threading.Tasks;
using IoT.Infra.Data;
using IoT.Infra.SocketsManagers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace IoT.Api.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly AppDbContext _dbContext;
        private bool _willCommit;

        public ApplicationController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
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