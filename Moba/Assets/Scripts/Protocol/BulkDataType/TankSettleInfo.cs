// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    // 战斗结束坦克信息
    public sealed class TankSettleInfo
    {
        public uint charOid;// 角色id
        public uint tankTpltId;// 坦克模板ID
        public int[] StatData;// 技术数据
        public int TeamMerit;// 战队贡献
        public int OldElo;// 旧的elo值
        public int NewElo;// 新的elo值
        public byte Award;// 是否有奖励
        public byte isWin;// 是否获胜
        public int RobotType;// 机器人类型  = 0 不是机器人
        public SettleGroup[] expVec;// 角色经验组成信息
        public SettleGroup[] coinVec;// 银币组成信息
        public SettleGroup[] tankExpVec;// 坦克经验组成信息
        public GiveItemStruct[] itemVec;// 掉落物品列表,服务端用
        public PVE_Evaluation_Result evalPve;// PVE过关评价
        public uint battleLevel;// 战场等级
        public uint eloSectionId;//天梯阶段ID
        public void ReadFromStream(BinaryReader reader)
        {
            charOid = reader.ReadUInt32();
            tankTpltId = reader.ReadUInt32();
            var length3 = reader.ReadUInt16();
            StatData = new int[length3];
            for (var i3 = 0; i3 < length3; i3++)
            {
                StatData[i3] = reader.ReadInt32();
            }
            TeamMerit = reader.ReadInt32();
            OldElo = reader.ReadInt32();
            NewElo = reader.ReadInt32();
            Award = reader.ReadByte();
            isWin = reader.ReadByte();
            RobotType = reader.ReadInt32();
            var length10 = reader.ReadUInt16();
            expVec = new SettleGroup[length10];
            for (var i10 = 0; i10 < length10; i10++)
            {
                expVec[i10] = new SettleGroup();
                expVec[i10].ReadFromStream(reader);
            }
            var length11 = reader.ReadUInt16();
            coinVec = new SettleGroup[length11];
            for (var i11 = 0; i11 < length11; i11++)
            {
                coinVec[i11] = new SettleGroup();
                coinVec[i11].ReadFromStream(reader);
            }
            var length12 = reader.ReadUInt16();
            tankExpVec = new SettleGroup[length12];
            for (var i12 = 0; i12 < length12; i12++)
            {
                tankExpVec[i12] = new SettleGroup();
                tankExpVec[i12].ReadFromStream(reader);
            }
            var length13 = reader.ReadUInt16();
            itemVec = new GiveItemStruct[length13];
            for (var i13 = 0; i13 < length13; i13++)
            {
                itemVec[i13] = new GiveItemStruct();
                itemVec[i13].ReadFromStream(reader);
            }
            evalPve = new PVE_Evaluation_Result();
            evalPve.ReadFromStream(reader);
            battleLevel = reader.ReadUInt32();
            eloSectionId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(charOid);
            writer.Write(tankTpltId);
            ushort count3 = (ushort)(StatData == null ? 0 : StatData.Length);
            writer.Write(count3);
            for(var i3 = 0; i3 < count3; i3++)
            {
                writer.Write(StatData[i3]);
            }
            writer.Write(TeamMerit);
            writer.Write(OldElo);
            writer.Write(NewElo);
            writer.Write(Award);
            writer.Write(isWin);
            writer.Write(RobotType);
            ushort count10 = (ushort)(expVec == null ? 0 : expVec.Length);
            writer.Write(count10);
            for(var i10 = 0; i10 < count10; i10++)
            {
                expVec[i10].WriteToStream(writer);
            }
            ushort count11 = (ushort)(coinVec == null ? 0 : coinVec.Length);
            writer.Write(count11);
            for(var i11 = 0; i11 < count11; i11++)
            {
                coinVec[i11].WriteToStream(writer);
            }
            ushort count12 = (ushort)(tankExpVec == null ? 0 : tankExpVec.Length);
            writer.Write(count12);
            for(var i12 = 0; i12 < count12; i12++)
            {
                tankExpVec[i12].WriteToStream(writer);
            }
            ushort count13 = (ushort)(itemVec == null ? 0 : itemVec.Length);
            writer.Write(count13);
            for(var i13 = 0; i13 < count13; i13++)
            {
                itemVec[i13].WriteToStream(writer);
            }
            evalPve.WriteToStream(writer);
            writer.Write(battleLevel);
            writer.Write(eloSectionId);
        }
    }
}
