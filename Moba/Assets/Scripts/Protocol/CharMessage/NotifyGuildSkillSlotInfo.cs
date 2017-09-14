// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    /// MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_SKIL_SLOT_INFO)       //通知角色军团技能槽信息
    public sealed class NotifyGuildSkillSlotInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_GUILD_SKIL_SLOT_INFO;
        public short GetMsgType { get { return MsgType; } }
        public GuildSkillSlotInfo[] skillSlotList;// 角色军团技能槽列表
        public uint SlotFlag;// 技能槽开启标志位 GUILD_SKILL_OPEN_FLAG
        
        public static void Send(GuildSkillSlotInfo[] skillSlotList, uint slotFlag, object className)
        {
            var packet = new NotifyGuildSkillSlotInfo
            {
                skillSlotList = skillSlotList,
                SlotFlag = slotFlag
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
            skillSlotList = new GuildSkillSlotInfo[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                skillSlotList[i1] = new GuildSkillSlotInfo();
                skillSlotList[i1].ReadFromStream(reader);
            }
            SlotFlag = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(skillSlotList == null ? 0 : skillSlotList.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                skillSlotList[i1].WriteToStream(writer);
            }
            writer.Write(SlotFlag);
        }
    }
}