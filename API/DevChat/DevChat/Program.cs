// Servidor WebSocket em C# (Console App)
using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Servidor WebSocket iniciado...");
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:5000/");
        listener.Start();

        while (true)
        {
            HttpListenerContext context = await listener.GetContextAsync();

            if (context.Request.IsWebSocketRequest)
            {
                _ = ProcessWebSocket(context);
            }
            else
            {
                context.Response.StatusCode = 400;
                context.Response.Close();
            }
        }
    }

    private static async Task ProcessWebSocket(HttpListenerContext context)
    {
        WebSocketContext wsContext = await context.AcceptWebSocketAsync(null);
        WebSocket webSocket = wsContext.WebSocket;

        byte[] buffer = new byte[1024];

        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Fechando", CancellationToken.None);
            }
            else
            {
                string mensagem = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"Recebido: {mensagem}");

                string resposta = $"Servidor recebeu: {mensagem}";
                byte[] respostaBytes = Encoding.UTF8.GetBytes(resposta);
                await webSocket.SendAsync(new ArraySegment<byte>(respostaBytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
