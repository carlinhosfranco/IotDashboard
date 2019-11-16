using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IoT.Domain.SocketsManager;

namespace IoT.Infra.SocketsManager
{
    public class TemperatureSocketManager : ITemperatureSocketManager
    {
        private static ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public TemperatureSocketManager()
        {
        }

        private async Task SendMessageAsync(WebSocket socket, string message)
        {
            if (socket.State != WebSocketState.Open)
                return;
    
            await socket.SendAsync(buffer: new ArraySegment<byte>(array: Encoding.ASCII.GetBytes(message),
                                                                    offset: 0,
                                                                    count: message.Length),
                                    messageType: WebSocketMessageType.Text,
                                    endOfMessage: true,
                                    cancellationToken: CancellationToken.None);
        }
        private string CreateConnectionId()
        {
            return Guid.NewGuid().ToString();
        } 
        public ConcurrentDictionary<string, WebSocket> GetAll()
        {
            return _sockets;
        }
        public WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(p => p.Key == id).Value;
        } 
        public string GetId(WebSocket socket)
        {
            return _sockets.FirstOrDefault(p => p.Value == socket).Key;
        }
        public string AddSocket(WebSocket socket)
        {
            var id = CreateConnectionId();
            _sockets.TryAdd(id, socket);
    
            return id;
        }    
        public async Task RemoveSocket(string id)
        {
            WebSocket socket;
            _sockets.TryRemove(id, out socket);
    
            await socket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
                                    statusDescription: "Closed by the WebSocketManager",
                                    cancellationToken: CancellationToken.None);
        }    
        public async Task SendMessageToAllAsync(string message)
        {
            foreach (var pair in _sockets)
            {
                if (pair.Value.State == WebSocketState.Open)
                {
                    //Console.WriteLine($"\n\n{pair.Value} \t {message}\n");
                    await SendMessageAsync(pair.Value, message);                    
                }
                    
            }
        }
    } 
    
}