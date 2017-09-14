using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Network;
using GameProtocol;
using Google.Protobuf;
using Server.RPC;

namespace Server.Manager
{
    public class ConnectionSummary
    {
        public int Total;
    }

    public static class ClientManager
    {
        private static readonly ConnectionSummary Summary = new ConnectionSummary();
        private static readonly ConcurrentDictionary<uint, ClientConnection> Connections = new ConcurrentDictionary<uint, ClientConnection>();

        private static ClientListener _listener;
        public static Action<uint> OnRemoveClient;

        public static Task Start(CancellationToken cancel)
        {
            _listener = new ClientListener(13000, cancel, AddClient);
            return _listener.Start();
        }

        public static void Stop()
        {
            _listener.Stop();
        }

        public static bool Containers(uint id)
        {
            return Connections.ContainsKey(id);
        }

        private static void AddClient(uint id, ClientConnection connection)
        {
            Interlocked.Increment(ref Summary.Total);
            Log.Write($"Connected {connection.Id}, {Summary.Total} client has connected", typeof(ClientManager));

            Log.Write($"Client Connect {id}", typeof(ClientManager));
            Connections.TryAdd(id, connection);
        }

        public static void RemoveClient(uint id)
        {
            Interlocked.Decrement(ref Summary.Total);
            Log.Write($"Disconnected {id}, {Summary.Total} client has connected", typeof(ClientManager));

            ClientConnection connection;
            if (!Connections.TryRemove(id, out connection))
                Log.Error("移除客户端失败", typeof(ClientManager));
            OnRemoveClient(id);
        }

        public static ClientConnection GetConnection(uint id)
        {
            ClientConnection net;
            Connections.TryGetValue(id, out net);
            return net;
        }

        public static void Send(uint id, ushort type, IMessage message, object className)
        {
            var net = GetConnection(id);
            NetMessage.Send(net, type, message, className);
        }

        public static ConcurrentDictionary<uint, ClientConnection> GetConnections => Connections;
    }
}