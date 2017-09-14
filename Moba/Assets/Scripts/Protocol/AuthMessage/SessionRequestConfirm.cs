// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AuthMessage
{
    /**
     * 认证前端->客户端：Session开始
     *
     * MSG_AUTH_SESSION_REQUESTCONFIRM
     */
    public sealed class SessionRequestConfirm : IProtocol
    {
        public const short MsgType = MessageType.MSG_AUTH_SESSION_REQUESTCONFIRM;
        public short GetMsgType { get { return MsgType; } }
        public uint is_valid;// 1表示有效的Sesison
        
        public static void Send(uint is_valid, object className)
        {
            var packet = new SessionRequestConfirm
            {
                is_valid = is_valid
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
            is_valid = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(is_valid);
        }
    }
}