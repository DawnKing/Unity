// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_GUILD_BOSS_DAMAGE_HP),
    // 通知之前军团BOSS被伤害血量(军团BOSS继承伤害)
    public sealed class NotifyGuildBossDamageHpMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_GUILD_BOSS_DAMAGE_HP;
        public short GetMsgType { get { return MsgType; } }
        public uint sceneId;// 场景ID
        public uint bossId;// BOOS ID
        public int guildBossDamageHp;// 军团BOSS被伤害血量
        
        public static void Send(uint sceneId, uint bossId, int guildBossDamageHp, object className)
        {
            var packet = new NotifyGuildBossDamageHpMessage
            {
                sceneId = sceneId,
                bossId = bossId,
                guildBossDamageHp = guildBossDamageHp
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
            sceneId = reader.ReadUInt32();
            bossId = reader.ReadUInt32();
            guildBossDamageHp = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(sceneId);
            writer.Write(bossId);
            writer.Write(guildBossDamageHp);
        }
    }
}
