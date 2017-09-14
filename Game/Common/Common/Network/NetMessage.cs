using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using GameProtocol;
using Google.Protobuf;

namespace Common.Network
{
    public static class NetMessage
    {
        private static readonly Dictionary<ushort, Type> PacketReader = new Dictionary<ushort, Type>();
        private static readonly Dictionary<string, ushort> MessageType = new Dictionary<string, ushort>();
        private static IDictionary _eventListener;
        private static readonly Queue<IMessage> CacheMessages = new Queue<IMessage>();

        public static NetConnection Connection; // socket连接，客户端用

        public static void Init(bool useId)
        {
            if (useId)
            {
                _eventListener = new Dictionary<ushort, Action<ProtocolMessage, uint>>();
            }
            else
            {
                _eventListener = new Dictionary<ushort, Action<IMessage>>();
            }
        }

        public static void AddListener(ushort type, Type obj, object callback)
        {
            try
            {
                MessageType.Add(obj.Name, type);
                PacketReader.Add(type, obj);
                _eventListener.Add(type, callback);
            }
            catch (Exception e)
            {
                Log.Error(e.Message + ", type = " + type, typeof(NetMessage));
            }
        }

        public static void AddListener(ushort type, Action<ProtocolMessage, uint> callback)
        {
            _eventListener.Add(type, callback);
        }

        public static void RemoveListener2(ushort type)
        {
            PacketReader.Remove(type);
            _eventListener.Remove(type);
        }

        public static void RemoveListener(ushort type)
        {
            _eventListener.Remove(type);
        }

        public static void DispatchMessage(ProtocolMessage message)
        {
            var type = (ushort)message.Type;
            if (!_eventListener.Contains(type))
            {
                Log.Warning("未处理" + type, typeof(NetMessage));
                return;
            }

            // NotifyCreateEntity.Parser.ParseFrom(messageData);
            var parser = PacketReader[type].GetProperty("Parser", BindingFlags.Public | BindingFlags.Static);
            var parserObj = parser.GetValue(null, null);
            var parserType = parser.PropertyType;
            MethodInfo parseFrom = parserType.GetMethod("ParseFrom", new[] { typeof(ByteString) });
            IMessage msg = parseFrom.Invoke(parserObj, new object[] { message.Data }) as IMessage;

            lock (CacheMessages)
            {
                CacheMessages.Enqueue(msg);
            }

            Log.Write($"收到协议{type}, 长度{message.CalculateSize()},  {msg.Descriptor.Name}", typeof(NetMessage));
        }

        public static void DispatchMessage(ProtocolMessage message, uint id)
        {
            var type = (ushort)message.Type;
            var listener = (Dictionary<ushort, Action<ProtocolMessage, uint>>)_eventListener;
            if (!listener.ContainsKey(type))
            {
                Log.Warning("未处理" + message.Type, typeof(NetMessage));
                return;
            }

            listener[type](message, id);
        }

        public static void Update()
        {
            // Unity不适合在子线程中解包处理逻辑，全部在主线程处理
            lock (CacheMessages)
            {
                while (CacheMessages.Count > 0)
                {
                    IMessage message = CacheMessages.Dequeue();

                    var type = MessageType[message.Descriptor.ClrType.Name];
                    Delegate callback = _eventListener[type] as Delegate;
                    callback.DynamicInvoke(message);
                }
            }
        }

        public static void Send(ushort type, IMessage message, object className)
        {
            Send(Connection, type, message, className);
        }

        public static void Send(NetConnection connection, ushort type, IMessage message, object className)
        {
            var proto = new ProtocolMessage
            {
                Type = type,
                Data = message.ToByteString()
            };

            connection.Send(proto, className);
        }
    }
}
