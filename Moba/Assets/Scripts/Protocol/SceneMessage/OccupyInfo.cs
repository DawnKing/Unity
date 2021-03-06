// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // 战场旗子占领信息
    public sealed class OccupyInfo
    {
        public int iIndex;// 旗子索引
        public int iCampId;// 旗子阵营
        public int iLock;// 是否锁定
        public int iOccupy;// 当前占领数据，红方为负值，蓝方为正值
        public uint scoreTime;// 上次给予积分时间
        public void ReadFromStream(BinaryReader reader)
        {
            iIndex = reader.ReadInt32();
            iCampId = reader.ReadInt32();
            iLock = reader.ReadInt32();
            iOccupy = reader.ReadInt32();
            scoreTime = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(iIndex);
            writer.Write(iCampId);
            writer.Write(iLock);
            writer.Write(iOccupy);
            writer.Write(scoreTime);
        }
    }
}
