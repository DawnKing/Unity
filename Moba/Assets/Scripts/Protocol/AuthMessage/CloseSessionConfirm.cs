// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AuthMessage
{
    /**
     * 认证前端->客户端：Session结束
     *
     * MSGTYPE_DECLARE(MSG_AUTH_SESSION_CLOSECONFIRM)
     */
    public sealed class CloseSessionConfirm : IProtocol
    {
        public const short MsgType = MessageType.MSG_AUTH_SESSION_CLOSECONFIRM;
        public short GetMsgType { get { return MsgType; } }
        public uint reason;// enum:AUTH_SESSION_RESULT
        
        public static void Send(uint reason, object className)
        {
            var packet = new CloseSessionConfirm
            {
                reason = reason
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
            reason = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(reason);
        }
    }
}
