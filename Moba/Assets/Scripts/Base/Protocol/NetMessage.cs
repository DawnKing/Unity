using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class NetMessage
{
    private static readonly Dictionary<short, MessageData> EventListener = new Dictionary<short, MessageData>();

    private static readonly Queue<IProtocol> CacheProtoObject = new Queue<IProtocol>();

    public static NetConnection NetConnection { get; set; }

    public static short GetType(Type obj)
    {
        short type = Convert.ToInt16(obj.GetField("MsgType").GetValue(obj));
        return type;
    }

    public static void AddListener(Type type, Action<IProtocol> callback)
    {
        short msgType = GetType(type);
        try
        {
            var data = new MessageData
            {
                Type = type,
                Callback = callback
            };
            EventListener.Add(msgType, data);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message + ", type = " + msgType);
        }
    }

    public static void RemoveListener(Type type)
    {
        short msgType = GetType(type);
        EventListener.Remove(msgType);
    }

    public static void DispatchMessage(byte[] bytes)
    {
        var readerMemory = new MemoryStream(bytes);
        var reader = new CustomBinaryReader(readerMemory);
        // 读取单个包
        var msgType = reader.ReadInt16();
        // 跳过包头，服务端需要用到，客户端没有用到
        readerMemory.Position += NetConnection.SkipPacketHead;
        // 消息处理程序
        DispatchMessage(msgType, reader, bytes.Length);
    }

    public static void DispatchMessage(short msgType, BinaryReader reader, int packetLength)
    {
        if (!EventListener.ContainsKey(msgType))
        {
#if UNITY_EDITOR
//            Debug.LogWarning(string.Format("未处理{0},   {1}", msgType, NetConnection.MessageType[msgType]));
#endif
            return;
        }

#if UNITY_EDITOR
//        Debug.Log(string.Format("收到协议{0}, 长度{1},  {2}", msgType, packetLength, NetConnection.MessageType[msgType]));
#endif

        var data = EventListener[msgType];
        IProtocol obj = (IProtocol)Activator.CreateInstance(data.Type);
        obj.ReadFromStream(reader);

        lock (CacheProtoObject)
        {
            CacheProtoObject.Enqueue(obj);
        }
    }

    public static void Update()
    {
        // Unity不适合在子线程中解包处理逻辑，全部在主线程处理
        lock (CacheProtoObject)
        {
            while (CacheProtoObject.Count > 0)
            {
                IProtocol obj = CacheProtoObject.Dequeue();

//                Debug.Log("处理协议" + obj.GetMsgType);
                EventListener[obj.GetMsgType].Callback(obj);
            }
        }
    }

    public static void Send(byte[] packet, object className)
    {
        NetConnection.Send(packet, className);
    }
}

class MessageData
{
    public Type Type;
    public Action<IProtocol> Callback;
}
