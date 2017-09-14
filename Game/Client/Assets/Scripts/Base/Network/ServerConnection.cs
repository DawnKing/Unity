using System;
using System.Net.Sockets;
using Common;
using Common.Network;
using GameProtocol;
using Google.Protobuf;
using UnityEngine;

namespace Assets.Scripts.Base.Network
{
    public class ServerConnection : NetConnection
    {
        public Action OnConnected;

        public ServerConnection()
        {
            Tcp = new TcpClient();
        }

        public override void Dispose()
        {
            base.Dispose();
            if (Tcp != null)
                Tcp.Close();
        }

        public override bool Send(IMessage message, object className)
        {
            if (!base.Send(message, className))
                return false;

            message.WriteTo(NetStream);

            return true;
        }

        public void Connect(string host, int port)
        {
            try
            {
                Tcp.BeginConnect(host, port, OnConnectedHandler, Tcp);
            }
            catch (Exception e)
            {
                Log.Write(e, this);
                Dispose();
            }
        }

        private void OnConnectedHandler(IAsyncResult ar)
        {
            try
            {
                Tcp.EndConnect(ar);

                OnConnected();

                NetStream = Tcp.GetStream();
                NetStream.BeginRead(CachePacket, 0, CachePacket.Length, OnRead, CachePacket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Dispose();
            }
        }

        private void OnRead(IAsyncResult ar)
        {
            if (!Core.Core.IsPlaying)
            { 
                Dispose();
                return;
            }

            var totalBytes = NetStream.EndRead(ar);
            if (totalBytes == 0)
            {
                Debug.Log("OnRead0");
                return;
            }
                
            ReceivePacket(totalBytes);

            NetStream.BeginRead(CachePacket, 0, CachePacket.Length, OnRead, CachePacket);
        }

        protected override void DispatchMessage(ProtocolMessage message)
        {
            NetMessage.DispatchMessage(message);
        }
    }
}
