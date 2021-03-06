// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MailMessage
{
    /// 通知邮件的详细信息
    public sealed class NotifyMailInsideInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_MAIL_INSIDE_INFO;
        public short GetMsgType { get { return MsgType; } }
        public MAIL_INSIDE_INFO info;
        
        public static void Send(MAIL_INSIDE_INFO info, object className)
        {
            var packet = new NotifyMailInsideInfo
            {
                info = info
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
            info = new MAIL_INSIDE_INFO();
            info.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            info.WriteToStream(writer);
        }
    }
}
