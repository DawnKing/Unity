// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MailMessage
{
    ///	通知有未读邮件
    public sealed class NotifyNoReadMailCount : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_MAIL_NOREAD_COUNT;
        public short GetMsgType { get { return MsgType; } }
        public int count;// 未读邮件的数量
        
        public static void Send(int count, object className)
        {
            var packet = new NotifyNoReadMailCount
            {
                count = count
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
            count = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(count);
        }
    }
}
