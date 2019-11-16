using System.Threading.Tasks;
using IoT.Domain.SocketsManager;
using Microsoft.AspNetCore.Http;

namespace IoT.Domain.SocketsMeddleware
{
    public interface ITemperatureSocketMiddleware
    {
        //Task Invoke(HttpContext context, ITemperatureSocketManager socketManager);         
        Task Invoke(HttpContext context);         
    }
}