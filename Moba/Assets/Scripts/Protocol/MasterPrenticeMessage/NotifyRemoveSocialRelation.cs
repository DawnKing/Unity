// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MasterPrenticeMessage
{
    // 通知移除师徒关系
    public sealed class NotifyRemoveSocialRelation : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_REMOVE_SOCIAL_REL;
        public short GetMsgType { get { return MsgType; } }
        public uint Type;// 社交关系类型
        public string tgtUuid;// 移除关系的目标UUID
        
        public static void Send(uint type, string tgtUuid, object className)
        {
            var packet = new NotifyRemoveSocialRelation
            {
                Type = type,
                tgtUuid = tgtUuid
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
            tgtUuid = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Type);
            writer.Write(tgtUuid);
        }
    }
}
