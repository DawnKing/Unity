// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.StoreMessage
{
    // 通知商店简要信息
    public sealed class NotifyStoreBrief : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_STORE_BRIEF;
        public short GetMsgType { get { return MsgType; } }
        public ushort ntoreType;// 商店类型, 参见STORE_TYPE
        public uint lastUpdate;// 最后一次刷新时间
        public uint refreshCount;// 刷新次数
        
        public static void Send(ushort ntoreType, uint lastUpdate, uint refreshCount, object className)
        {
            var packet = new NotifyStoreBrief
            {
                ntoreType = ntoreType,
                lastUpdate = lastUpdate,
                refreshCount = refreshCount
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
            ntoreType = reader.ReadUInt16();
            lastUpdate = reader.ReadUInt32();
            refreshCount = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(ntoreType);
            writer.Write(lastUpdate);
            writer.Write(refreshCount);
        }
    }
}
