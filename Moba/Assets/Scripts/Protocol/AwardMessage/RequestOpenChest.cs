// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AwardMessage
{
    // 开宝箱类型
    // 开一次
    // 开十次
    // MSGTYPE_DECLARE(MSG_REQUEST_OPEN_CHEST),
    // 请求开宝箱
    public sealed class RequestOpenChest : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_OPEN_CHEST;
        public short GetMsgType { get { return MsgType; } }
        public uint opType;// 开宝箱类型(OPEN_CHEST_TYPE)
        
        public static void Send(uint opType, object className)
        {
            var packet = new RequestOpenChest
            {
                opType = opType
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
            opType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(opType);
        }
    }
}