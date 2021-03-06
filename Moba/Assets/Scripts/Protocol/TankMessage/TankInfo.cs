// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.TankMessage
{
    // ----------------------------------------------------------------------
    ///    @file            protocol/TankMessage.h
    ///    @brief
    ///    @author          linyixiong
    ///    @copyright       Sixcube Information Technology Co,. Ltd. (2012)
    ///    @date
    // ----------------------------------------------------------------------
    // 角色信息
    public sealed class TankInfo
    {
        public uint acctOid;// 玩家id（唯一的id）
        public short x;// x 坐标
        public short y;// y 坐标
        public int hp;// 坦克血条
        public int maxHp;// 此坦克的血条上限
        public byte Star;// 坦克星级
        public byte Camp;// 阵营信息，1,红方；2，蓝方
        public string name;// 玩家名字
        public BuffInfo[] buffVec;// buff信息
        public short lifeCount;// 命数 -1:表示无限
        public uint curBattleExp;// 当前战场经验
        public byte battleLevel;// 当前战场等级
        public byte tankLevel;// 坦克等级
        public int mp;// 能量当前值
        public int maxMp;// 能量上限
        public void ReadFromStream(BinaryReader reader)
        {
            acctOid = reader.ReadUInt32();
            x = reader.ReadInt16();
            y = reader.ReadInt16();
            hp = reader.ReadInt32();
            maxHp = reader.ReadInt32();
            Star = reader.ReadByte();
            Camp = reader.ReadByte();
            name = reader.ReadString();
            var length9 = reader.ReadUInt16();
            buffVec = new BuffInfo[length9];
            for (var i9 = 0; i9 < length9; i9++)
            {
                buffVec[i9] = new BuffInfo();
                buffVec[i9].ReadFromStream(reader);
            }
            lifeCount = reader.ReadInt16();
            curBattleExp = reader.ReadUInt32();
            battleLevel = reader.ReadByte();
            tankLevel = reader.ReadByte();
            mp = reader.ReadInt32();
            maxMp = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(acctOid);
            writer.Write(x);
            writer.Write(y);
            writer.Write(hp);
            writer.Write(maxHp);
            writer.Write(Star);
            writer.Write(Camp);
            writer.Write(name);
            ushort count9 = (ushort)(buffVec == null ? 0 : buffVec.Length);
            writer.Write(count9);
            for(var i9 = 0; i9 < count9; i9++)
            {
                buffVec[i9].WriteToStream(writer);
            }
            writer.Write(lifeCount);
            writer.Write(curBattleExp);
            writer.Write(battleLevel);
            writer.Write(tankLevel);
            writer.Write(mp);
            writer.Write(maxMp);
        }
    }
}
