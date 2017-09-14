// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.QuestMessage
{
    // 通知任务信息
    public sealed class NotifyQuestList : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_QUEST_LIST;
        public short GetMsgType { get { return MsgType; } }
        public QuestInfo[] questVec;
        public int type;
        
        public static void Send(QuestInfo[] questVec, int type, object className)
        {
            var packet = new NotifyQuestList
            {
                questVec = questVec,
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
            var length1 = reader.ReadUInt16();
            questVec = new QuestInfo[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                questVec[i1] = new QuestInfo();
                questVec[i1].ReadFromStream(reader);
            }
            type = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(questVec == null ? 0 : questVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                questVec[i1].WriteToStream(writer);
            }
            writer.Write(type);
        }
    }
}