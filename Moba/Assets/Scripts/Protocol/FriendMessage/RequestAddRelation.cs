// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.FriendMessage
{
    /// 请求建立关系
    public sealed class RequestAddRelation : IProtocol
    {
        public const short MsgType = MessageType.MSG_RELATION_REQUEST_ADD;
        public short GetMsgType { get { return MsgType; } }
        public string strName;// 对方的名称
        public int type;// 关系类型
        
        public static void Send(string strName, int type, object className)
        {
            var packet = new RequestAddRelation
            {
                strName = strName,
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
            strName = reader.ReadString();
            type = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(strName);
            writer.Write(type);
        }
    }
}
