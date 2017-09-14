// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.FriendMessage
{
    /// 通知删除关系
    public sealed class NotifyDeleteRelation : IProtocol
    {
        public const short MsgType = MessageType.MSG_RELATION_DELETE;
        public short GetMsgType { get { return MsgType; } }
        public string charUuid;// 对方的uuid
        public int type;// 类型
        
        public static void Send(string charUuid, int type, object className)
        {
            var packet = new NotifyDeleteRelation
            {
                charUuid = charUuid,
                type = type
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
            charUuid = reader.ReadString();
            type = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(charUuid);
            writer.Write(type);
        }
    }
}
