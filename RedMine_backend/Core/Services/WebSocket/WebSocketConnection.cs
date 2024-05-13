using RedMine_backend.Core.DataBase;
using RedMine_backend.Core.Services;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketApiControllerExample
{
    public interface IConnection
    {
        Task<WebSocketCloseStatus?> KeepReceiving();
        Task Send(string message);
        Task Close();
    }

    public class WebSocketConnection : IConnection
    {
        private readonly WebSocket _webSocket;

        public WebSocketConnection(WebSocket webSocket)
        {
            _webSocket = webSocket;
        }

        public async Task<WebSocketCloseStatus?> KeepReceiving()
        {
            WebSocketReceiveResult message;
            do
            {
                using (var memoryStream = new MemoryStream())
                {
                    message = await ReceiveMessage(memoryStream);
                    if (message.Count > 0)
                    {
                        
                        DataBaseOperations result = new DataBaseOperations();
                        string receivedMessage = Encoding.UTF8.GetString(memoryStream.ToArray());
                        
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            IgnoreNullValues = true
                        };

                        TasksParamDto userData = JsonSerializer.Deserialize<TasksParamDto>(receivedMessage, options);
                        TasksParamDto valami = new TasksParamDto();
                        Console.WriteLine(receivedMessage);
                        var res = await result.GetDeadLine(userData.UserID);
                        await Send(JsonSerializer.Serialize(res));
                    }
                }
            } while (message.MessageType != WebSocketMessageType.Close);

            return message.CloseStatus;
        }

        private async Task<WebSocketReceiveResult> ReceiveMessage(Stream memoryStream)
        {
            var readBuffer = new ArraySegment<byte>(new byte[4 * 1024]);
            WebSocketReceiveResult result;
            do
            {
                result = await _webSocket.ReceiveAsync(readBuffer, CancellationToken.None);
                await memoryStream.WriteAsync(readBuffer.Array, readBuffer.Offset, result.Count,
                    CancellationToken.None);
            } while (!result.EndOfMessage);

            return result;
        }

        public async Task Send(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            await _webSocket.SendAsync(new ArraySegment<byte>(bytes, 0, bytes.Length), WebSocketMessageType.Text, true,
                CancellationToken.None);
        }

        public async Task Close()
        {
            await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
        }
    }
}