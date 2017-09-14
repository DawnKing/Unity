// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MasterPrenticeMessage
{
    // MSGTYPE_DECLARE(MSG_APPROVE_MP_RELATION_APPLY),
    // 同意建立师徒关系
    public sealed class ApproveMPApply : IProtocol
    {
        public const short MsgType = MessageType.MSG_APPROVE_MP_RELATION_APPLY;
        public short GetMsgType { get { return MsgType; } }
        public string strUuid;// 申请者UUID
        
        public static void Send(string strUuid, object className)
        {
            var packet = new ApproveMPApply
            {
                strUuid = strUuid
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
            strUuid = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(strUuid);
        }
    }
}
