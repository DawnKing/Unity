// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    // 单人副本关卡信息
    public sealed class CHAPTER_SCENE
    {
        public uint MapId;// 关卡ID
        public uint PassDate;// 上次过关时间（0表示未过关或被收回）
        public ushort PassTimes;// 本日已经通关次数
        public uint BeHarm;// 最少掉血量
        public ushort DiedTimes;// 最少死亡次数
        public uint Scores;// 最高得分
        public ushort Stars;// 最高星级
        public ushort StarsToday;// 本日星级
        public ushort Elapsed;// 最短耗时（秒）
        public ushort SettleFlag;// 收益标记，参见PVE_SETTEL_FLAG
        public uint SettleDate;// 收益结算时间
        public ushort ResetTimes;// 本日重置次数
        public void ReadFromStream(BinaryReader reader)
        {
            MapId = reader.ReadUInt32();
            PassDate = reader.ReadUInt32();
            PassTimes = reader.ReadUInt16();
            BeHarm = reader.ReadUInt32();
            DiedTimes = reader.ReadUInt16();
            Scores = reader.ReadUInt32();
            Stars = reader.ReadUInt16();
            StarsToday = reader.ReadUInt16();
            Elapsed = reader.ReadUInt16();
            SettleFlag = reader.ReadUInt16();
            SettleDate = reader.ReadUInt32();
            ResetTimes = reader.ReadUInt16();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(MapId);
            writer.Write(PassDate);
            writer.Write(PassTimes);
            writer.Write(BeHarm);
            writer.Write(DiedTimes);
            writer.Write(Scores);
            writer.Write(Stars);
            writer.Write(StarsToday);
            writer.Write(Elapsed);
            writer.Write(SettleFlag);
            writer.Write(SettleDate);
            writer.Write(ResetTimes);
        }
    }
}
