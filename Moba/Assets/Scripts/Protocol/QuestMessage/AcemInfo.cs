// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.QuestMessage
{
    public sealed class AcemInfo
    {
        public uint Id;// 成就id
        public uint OpenTime;// 成就开启时间点
        public uint State;// 成就状态 enum ACHIEVEMENT_STATE_TYPE (AST_CLOSED,AST_OPEN)
        public uint CheckCount;// 检查点数量
        public void ReadFromStream(BinaryReader reader)
        {
            Id = reader.ReadUInt32();
            OpenTime = reader.ReadUInt32();
            State = reader.ReadUInt32();
            CheckCount = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Id);
            writer.Write(OpenTime);
            writer.Write(State);
            writer.Write(CheckCount);
        }
    }
}
