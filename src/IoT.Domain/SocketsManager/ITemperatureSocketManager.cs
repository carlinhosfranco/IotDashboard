using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace IoT.Domain.SocketsManager
{
    public interface ITemperatureSocketManager
    {
        ConcurrentDictionary<string, WebSocket> GetAll();
        WebSocket GetSocketById(string id);
        string GetId(WebSocket socket);
        string AddSocket(WebSocket socket);
        Task RemoveSocket(string id);
        Task SendMessageToAllAsync(string message);         
    }
}