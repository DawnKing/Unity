// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // 通知玩家选坦克阶段，指挥官技能发生变化
    public sealed class NotifyCommandSkillSelected : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_COMMAND_SKILL_SELECT;
        public short GetMsgType { get { return MsgType; } }
        public uint CharOid;// 玩家OID
        public uint CommandSkill;// 指挥官技能
        
        public static void Send(uint charOid, uint commandSkill, object className)
        {
            var packet = new NotifyCommandSkillSelected
            {
                CharOid = charOid,
                CommandSkill = commandSkill
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
            CharOid = reader.ReadUInt32();
            CommandSkill = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(CharOid);
            writer.Write(CommandSkill);
        }
    }
}
