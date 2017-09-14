using System;
using System.Timers;
using Common.Network;
using GameProtocol;
using Server.RPC;

namespace Server.Manager
{
    public static class PingManager
    {
        public static void Start()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += HandleTimer;
            timer.Start();
        }

        private static void HandleTimer(object sender, ElapsedEventArgs e)
        {
            var connections = ClientManager.GetConnections;
            foreach (var connection in connections)
            {
                ClientConnection client = connection.Value;
                var notify = new NotifyPing
                {
                    Time = DateTime.UtcNow.Millisecond
                };
//            Log.Write($"ping {notify.Time}", typeof(PingManager));
                ClientManager.Send(client.Id, MessageType.NotifyPing, notify, "PingManager");
            }
        }
    }
}