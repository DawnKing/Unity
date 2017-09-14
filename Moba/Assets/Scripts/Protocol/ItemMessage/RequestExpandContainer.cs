// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ItemMessage
{
    /// 请求扩展杂货格
    public sealed class RequestExpandContainer : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_EXPAND_CONTAINER;
        public short GetMsgType { get { return MsgType; } }
        public uint Type;/// 容器类型CONTAINER_TYPE
        
        public static void Send(uint type, object className)
        {
            var packet = new RequestExpandContainer
            {
                Type = type
            };
            NetMessage.Send(packet.BuildPacket(), className);
        }
        
        public byte[] BuildPacket()
        {
            var buffer = ProtocolBuffer.Writer;
            buffer.Write(MsgType);
            buffer.Write(ProtocolBuffer.Zero);
            WriteToStream(buffer);
            return ProtocolBuffer.CacheStream.ToArray();
        }
        
        public void ReadFromStream(BinaryReader reader)
        {
            Type = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Type);
        }
    }
}
