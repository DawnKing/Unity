using System;
using System.Net.Sockets;
using GameProtocol;
using Google.Protobuf;

namespace Common.Network
{
    public class NetConnection
    {
        protected readonly byte[] CachePacket = new byte[64 * 1024];    // 一个包大小最多64KB

        protected TcpClient Tcp;
        protected NetworkStream NetStream;

        public virtual void Dispose()
        {
            NetStream?.Dispose();
        }

        public void Close()
        {
            NetStream?.Close();
            Tcp?.Close();
        }

        public virtual bool Send(IMessage message, object className)
        {
            if (Tcp == null || !Tcp.Connected)
            {
                Log.Error("网络未连接", className);
                return false;
            }

            if (className is string)
            {
                Log.Write($"Send {message.CalculateSize()}bytes", className);
            }
            else
            {
                Log.Write($"Send {message.CalculateSize()}bytes", className);
            }

            return true;
        }

        protected void ReceivePacket(int totalBytes)
        {
            Log.Write($"Receive {totalBytes}bytes", this);

            var packet = new byte[totalBytes];
            Array.Copy(CachePacket, packet, totalBytes);
            var message = ProtocolMessage.Parser.ParseFrom(packet);
            DispatchMessage(message);
        }

        protected virtual void DispatchMessage(ProtocolMessage message)
        {
            Log.Error("DispatchMessage", this);
        }

        public bool Connected()
        {
            return Tcp.Connected;
        }
    }
}
