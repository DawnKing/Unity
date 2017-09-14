// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ActivityMessage
{
    // MSGTYPE_DECLARE(MSG_ACTIVITY_SYNC_BOSS_DATA),
    // 通知客户端, 同步世界boss活动信息
    public sealed class ActivitySyncBossData : IProtocol
    {
        public const short MsgType = MessageType.MSG_ACTIVITY_SYNC_BOSS_DATA;
        public short GetMsgType { get { return MsgType; } }
        public int ActId;// 活动模板id
        public int BossHp;// boss当前血量
        public int BossMaxHp;// boss最大血量
        public HarmBossInfo[] rankVec;// 伤害前10名的信息
        
        public static void Send(int actId, int bossHp, int bossMaxHp, HarmBossInfo[] rankVec, object className)
        {
            var packet = new ActivitySyncBossData
            {
                ActId = actId,
                BossHp = bossHp,
                BossMaxHp = bossMaxHp,
                rankVec = rankVec
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
            ActId = reader.ReadInt32();
            BossHp = reader.ReadInt32();
            BossMaxHp = reader.ReadInt32();
            var length4 = reader.ReadUInt16();
            rankVec = new HarmBossInfo[length4];
            for (var i4 = 0; i4 < length4; i4++)
            {
                rankVec[i4] = new HarmBossInfo();
                rankVec[i4].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(ActId);
            writer.Write(BossHp);
            writer.Write(BossMaxHp);
            ushort count4 = (ushort)(rankVec == null ? 0 : rankVec.Length);
            writer.Write(count4);
            for(var i4 = 0; i4 < count4; i4++)
            {
                rankVec[i4].WriteToStream(writer);
            }
        }
    }
}