// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.SceneMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_BATTLE_END),
    /// 通知战斗结束，退出战场
    public sealed class NotifyBattleEnd : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_BATTLE_END;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;// 场景id
        public uint MapId;// 地图ID
        public uint battleTime;// 战斗时间
        public byte roomType;// 房间类型 enum ROOM_TYPE
        public byte winCamp;// 获胜的阵营 enum CAMP_TYPE
        public byte winType;// 胜利类型 enum BATTLE_WIN_TYPE
        public int rebLifeCount;// 红方总坦克命数
        public int buleLifeCount;// 蓝方总坦克命数
        public TankSettleInfo[] tankVec;// 统计数据列表
        public TankSettleInfo[] escapeVec;// 逃跑玩家的统计数据列表
        public float svrExpRate;// 服务器战斗经验倍率
        public byte bpvpActOpen;// 是否有开启pvp活动掉落
        public uint ItemDropRate;// 服务器物品掉落倍率
        public uint Killer;// 杀戮者ID
        public uint Assister;// 助攻王
        public uint KDA;// 全能王
        public uint Destroyer;// 拆迁办
        public string sceneUuid;// 战场UUID
        
        public static void Send(uint sceneId, uint mapId, uint battleTime, byte roomType, byte winCamp, byte winType, int rebLifeCount, int buleLifeCount, TankSettleInfo[] tankVec, TankSettleInfo[] escapeVec, float svrExpRate, byte bpvpActOpen, uint itemDropRate, uint killer, uint assister, uint kDA, uint destroyer, string sceneUuid, object className)
        {
            var packet = new NotifyBattleEnd
            {
                SceneId = sceneId,
                MapId = mapId,
                battleTime = battleTime,
                roomType = roomType,
                winCamp = winCamp,
                winType = winType,
                rebLifeCount = rebLifeCount,
                buleLifeCount = buleLifeCount,
                tankVec = tankVec,
                escapeVec = escapeVec,
                svrExpRate = svrExpRate,
                bpvpActOpen = bpvpActOpen,
                ItemDropRate = itemDropRate,
                Killer = killer,
                Assister = assister,
                KDA = kDA,
                Destroyer = destroyer,
                sceneUuid = sceneUuid
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
            SceneId = reader.ReadUInt32();
            MapId = reader.ReadUInt32();
            battleTime = reader.ReadUInt32();
            roomType = reader.ReadByte();
            winCamp = reader.ReadByte();
            winType = reader.ReadByte();
            rebLifeCount = reader.ReadInt32();
            buleLifeCount = reader.ReadInt32();
            var length9 = reader.ReadUInt16();
            tankVec = new TankSettleInfo[length9];
            for (var i9 = 0; i9 < length9; i9++)
            {
                tankVec[i9] = new TankSettleInfo();
                tankVec[i9].ReadFromStream(reader);
            }
            var length10 = reader.ReadUInt16();
            escapeVec = new TankSettleInfo[length10];
            for (var i10 = 0; i10 < length10; i10++)
            {
                escapeVec[i10] = new TankSettleInfo();
                escapeVec[i10].ReadFromStream(reader);
            }
            svrExpRate = reader.ReadSingle();
            bpvpActOpen = reader.ReadByte();
            ItemDropRate = reader.ReadUInt32();
            Killer = reader.ReadUInt32();
            Assister = reader.ReadUInt32();
            KDA = reader.ReadUInt32();
            Destroyer = reader.ReadUInt32();
            sceneUuid = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(MapId);
            writer.Write(battleTime);
            writer.Write(roomType);
            writer.Write(winCamp);
            writer.Write(winType);
            writer.Write(rebLifeCount);
            writer.Write(buleLifeCount);
            ushort count9 = (ushort)(tankVec == null ? 0 : tankVec.Length);
            writer.Write(count9);
            for(var i9 = 0; i9 < count9; i9++)
            {
                tankVec[i9].WriteToStream(writer);
            }
            ushort count10 = (ushort)(escapeVec == null ? 0 : escapeVec.Length);
            writer.Write(count10);
            for(var i10 = 0; i10 < count10; i10++)
            {
                escapeVec[i10].WriteToStream(writer);
            }
            writer.Write(svrExpRate);
            writer.Write(bpvpActOpen);
            writer.Write(ItemDropRate);
            writer.Write(Killer);
            writer.Write(Assister);
            writer.Write(KDA);
            writer.Write(Destroyer);
            writer.Write(sceneUuid);
        }
    }
}
