// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    // 玩家列表数据结构
    public sealed class PLAYER_BRIEF
    {
        public uint nAcctId;// 帐号id
        public string szCharUuid;// 角色uuid
        public string szName;// 名字
        public byte bLevel;// 等级
        public byte bSex;// 角色性别
        public byte nVipLevel;// vip等级
        public uint nAvatar;// 外观ID
        public uint nDecorateId;// 角色主题装饰ID
        public uint nGraduate;// 出徒人数
        public int iElo;// 天梯elo值
        public uint nHonorId;// 荣誉Id
        public uint nBoosterAttack;// 助手战力
        public uint eloSectionId;// 本赛季段位
        public uint preEloSectionId;// 上赛季段位
        public uint nTeamPlace;// 战队名次，无战队为0
        public string szTeamName;// 战队名字
        public void ReadFromStream(BinaryReader reader)
        {
            nAcctId = reader.ReadUInt32();
            szCharUuid = reader.ReadString();
            szName = reader.ReadString();
            bLevel = reader.ReadByte();
            bSex = reader.ReadByte();
            nVipLevel = reader.ReadByte();
            nAvatar = reader.ReadUInt32();
            nDecorateId = reader.ReadUInt32();
            nGraduate = reader.ReadUInt32();
            iElo = reader.ReadInt32();
            nHonorId = reader.ReadUInt32();
            nBoosterAttack = reader.ReadUInt32();
            eloSectionId = reader.ReadUInt32();
            preEloSectionId = reader.ReadUInt32();
            nTeamPlace = reader.ReadUInt32();
            szTeamName = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(nAcctId);
            writer.Write(szCharUuid);
            writer.Write(szName);
            writer.Write(bLevel);
            writer.Write(bSex);
            writer.Write(nVipLevel);
            writer.Write(nAvatar);
            writer.Write(nDecorateId);
            writer.Write(nGraduate);
            writer.Write(iElo);
            writer.Write(nHonorId);
            writer.Write(nBoosterAttack);
            writer.Write(eloSectionId);
            writer.Write(preEloSectionId);
            writer.Write(nTeamPlace);
            writer.Write(szTeamName);
        }
    }
}