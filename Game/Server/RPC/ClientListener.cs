using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace Server.RPC
{
    public class ClientListener
    {
        private readonly int _port;
        private TcpListener _listener;
        private CancellationToken _cancel;
        private uint _totalId;

        public Action<uint, ClientConnection> OnConnectClient;

        public ClientListener(int port, CancellationToken cancel, Action<uint, ClientConnection> connectionClient)
        {
            _port = port;
            _cancel = cancel;

            OnConnectClient = connectionClient;
        }

        public async Task Start()
        {
            _listener = TcpListener.Create(_port);
            _listener.Start();

            Log.Write($"{DateTime.Now:HH:mm:ss} Server has started successfully!", this);

            await Task.Yield();

            while (!_cancel.IsCancellationRequested)
            {
                try
                {
                    Task timeoutTask = Task.Delay(2000, _cancel);
                    var acceptTask = _listener.AcceptTcpClientAsync();

                    await Task.WhenAny(timeoutTask, acceptTask);
                    if (!acceptTask.IsCompleted)
                        continue;

                    TcpClient client = await acceptTask;

                    var id = _totalId++;
                    var connection = new ClientConnection(id, client);
                    connection.Listen(_cancel);

                    OnConnectClient(id, connection);
                }
                catch (Exception e)
                {
                    Log.Write(e, this);
                }
            }

            Log.Write($"{DateTime.Now:HH:mm:ss} End Listener loop!", this);
        }

        public void Stop()
        {
            _listener?.Stop();
            Log.Write($"{DateTime.Now:HH:mm:ss} Stop Listener!", this);
        }
    }
}
