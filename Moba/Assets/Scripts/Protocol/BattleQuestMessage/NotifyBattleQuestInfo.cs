// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BattleQuestMessage
{
    // 通知玩家战场任务信息
    public sealed class NotifyBattleQuestInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_BATTLE_QUEST_INFO;
        public short GetMsgType { get { return MsgType; } }
        public BattleQuestInfo questInfo;
        
        public static void Send(BattleQuestInfo questInfo, object className)
        {
            var packet = new NotifyBattleQuestInfo
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
            questInfo = new BattleQuestInfo();
            questInfo.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            questInfo.WriteToStream(writer);
        }
    }
}
