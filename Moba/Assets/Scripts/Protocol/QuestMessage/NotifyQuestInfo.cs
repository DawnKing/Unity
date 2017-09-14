// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.QuestMessage
{
    // 单个玩家任务信息
    public sealed class NotifyQuestInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_QUEST_INFO;
        public short GetMsgType { get { return MsgType; } }
        public QuestInfo questInfo;
        
        public static void Send(QuestInfo questInfo, object className)
        {
            var packet = new NotifyQuestInfo
            {
                questInfo = questInfo
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
            questInfo = new QuestInfo();
            questInfo.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            questInfo.WriteToStream(writer);
        }
    }
}
