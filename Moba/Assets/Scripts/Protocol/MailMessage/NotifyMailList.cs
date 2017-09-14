// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MailMessage
{
    /// 通知邮件列表
    public sealed class NotifyMailList : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_MAIL_LIST;
        public short GetMsgType { get { return MsgType; } }
        public MAIL_BRIEF_INFO[] briefList;
        
        public static void Send(MAIL_BRIEF_INFO[] briefList, object className)
        {
            var packet = new NotifyMailList
            {
                briefList = briefList
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
            var length1 = reader.ReadUInt16();
            briefList = new MAIL_BRIEF_INFO[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                briefList[i1] = new MAIL_BRIEF_INFO();
                briefList[i1].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(briefList == null ? 0 : briefList.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                briefList[i1].WriteToStream(writer);
            }
        }
    }
}