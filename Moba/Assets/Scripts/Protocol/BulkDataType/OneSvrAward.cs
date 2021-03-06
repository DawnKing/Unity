// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    /// 近期获奖信息
    public sealed class OneSvrAward
    {
        public string strName;// 名字
        public uint rollId;// 轮盘id
        public int Count;// 物品数量
        public uint Time;// 获得的时间戳
        public void ReadFromStream(BinaryReader reader)
        {
            strName = reader.ReadString();
            rollId = reader.ReadUInt32();
            Count = reader.ReadInt32();
            Time = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(strName);
            writer.Write(rollId);
            writer.Write(Count);
            writer.Write(Time);
        }
    }
}
