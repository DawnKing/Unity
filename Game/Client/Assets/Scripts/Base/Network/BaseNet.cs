using System;
using System.Collections.Generic;
using Common.Network;
using Google.Protobuf;

namespace Assets.Scripts.Base.Network
{
    public class BaseNet
    {
        protected List<ushort> Msg = new List<ushort>();

        public virtual void Dispose()
        {
            RemoveMessage();
        }

        public void AddMessage(ushort type, Type obj, Action<IMessage> callback)
        {
            Msg.Add(type);
            NetMessage.AddListener(type, obj, callback);
        }

        public void RemoveMessage()
        {
            foreach (var type in Msg)
            {
                NetMessage.RemoveListener2(type);
            }
        }
    }
}