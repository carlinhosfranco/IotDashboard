using IoT.Domain.SocketsMeddleware;
using Microsoft.AspNetCore.Http;

namespace IoT.Infra.SocketsMeddleware
{
    public class PeopleSocketMiddleware : IPeopleSocketMiddleware
    {
        private readonly RequestDelegate _next;
        
    }
}