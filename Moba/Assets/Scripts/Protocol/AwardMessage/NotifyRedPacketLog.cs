// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AwardMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_REDPACKET_LOG),
    // 通知所有红包记录
    public sealed class NotifyRedPacketLog : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_REDPACKET_LOG;
        public short GetMsgType { get { return MsgType; } }
        public RedPktLog[] logList;// 红包记录
        
        public static void Send(RedPktLog[] logList, object className)
        {
            var packet = new NotifyRedPacketLog
            {
                logList = logList
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
            logList = new RedPktLog[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                logList[i1] = new RedPktLog();
                logList[i1].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(logList == null ? 0 : logList.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                logList[i1].WriteToStream(writer);
            }
        }
    }
}