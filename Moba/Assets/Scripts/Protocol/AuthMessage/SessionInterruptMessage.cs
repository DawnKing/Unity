// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AuthMessage
{
    /**
     * 网关->客户端：Session被中断
     * 
     * MSGTYPE_DECLARE(MSG_AUTH_SESSION_INTERRUPTED),
     */
    public sealed class SessionInterruptMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_AUTH_SESSION_INTERRUPTED;
        public short GetMsgType { get { return MsgType; } }
        public const int SRR_BEING_KICKED = 0;// 有新的正确登录
        public const int SRR_SESSION_EXPIRED = 1;// SESSION超时
        public const int SRR_SESSION_OUTOFFEE = 2;// 点卡余额不足
        public uint reason;///! @see SRR_REASON
        
        public static void Send(uint reason, object className)
        {
            var packet = new SessionInterruptMessage
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
