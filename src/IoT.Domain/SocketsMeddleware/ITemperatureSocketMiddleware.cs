using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace IoT.Domain.SocketsMeddleware
{
    public interface ITemperatureSocketMiddleware
    {
        //Task Invoke(HttpContext context, ITemperatureSocketManager socketManager);         
        Task Invoke(HttpContext context);         
    }
}