// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.QuestMessage
{
    // 删除任务信息
    public sealed class NotifyDeleteQuest : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_DELETE_QUEST;
        public short GetMsgType { get { return MsgType; } }
        public uint[] questIdVec;
        
        public static void Send(uint[] questIdVec, object className)
        {
            var packet = new NotifyDeleteQuest
            {
                questIdVec = questIdVec
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
            questIdVec = new uint[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                questIdVec[i1] = reader.ReadUInt32();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(questIdVec == null ? 0 : questIdVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                writer.Write(questIdVec[i1]);
            }
        }
    }
}