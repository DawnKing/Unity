using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Network;
using GameProtocol;
using Google.Protobuf;
using Server.Manager;

namespace Server.RPC
{
    public class ClientConnection : NetConnection
    {
        public uint Id { get; }

        public ClientConnection(uint id, TcpClient tcp)
        {
            Id = id;
            Tcp = tcp;
        }

        public override void Dispose()
        {
            base.Dispose();
            Tcp?.Dispose();
        }

        public override bool Send(IMessage message, object className)
        {
            if (!base.Send(message, className))
                return false;

            try
            {
                message.WriteTo(NetStream);
            }
            catch (Exception)
            {
                Dispose();
            }

            return true;
        }

        public async void Listen(CancellationToken cancel)
        {
            await Task.Yield();

            string local = Tcp.Client.LocalEndPoint.ToString();

            try
            {
                NetStream = Tcp.GetStream();

                while (!cancel.IsCancellationRequested && Tcp.Connected)
                {
                    if (!NetStream.DataAvailable)
                        continue;
                    var totalBytes = await NetStream.ReadAsync(CachePacket, 0, Tcp.Available, cancel);

                    ReceivePacket(totalBytes);
                }
            }
            catch (Exception e)
            {
                Log.Write(e, this);
            }

            ClientManager.RemoveClient(Id);
            Log.Write($"Disconnected {local}", this);
            Dispose();
        }

        protected override void DispatchMessage(ProtocolMessage message)
        {
            NetMessage.DispatchMessage(message, Id);
        }
    }
}
