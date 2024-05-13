using System.Net.WebSockets;

namespace WebSocketApiControllerService
{
    public interface IConnectionFactory
    {
        IConnection CreateConnection(WebSocket webSocket);
    }

    public class ConnectionFactory : IConnectionFactory
    {
        public IConnection CreateConnection(WebSocket webSocket)
        {
            return new WebSocketConnection(webSocket);
        }
    }
}