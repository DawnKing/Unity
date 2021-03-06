// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    // 坦克简要信息，用于gate与track同步
    public sealed class TANK_BRIEF
    {
        public uint TankId;// 坦克ID
        public byte TankCont;// 坦克容器 enum TANK_CONTAINER_TYPE
        public byte TankLevel;// 坦克等级
        public uint TankExt;// 坦克外观
        public uint ExistTime;// 存在时间
        public byte SkinFrameType;// 坦克皮肤边框
        public uint commanderSkill;// 指挥官技能
        public void ReadFromStream(BinaryReader reader)
        {
            TankId = reader.ReadUInt32();
            TankCont = reader.ReadByte();
            TankLevel = reader.ReadByte();
            TankExt = reader.ReadUInt32();
            ExistTime = reader.ReadUInt32();
            SkinFrameType = reader.ReadByte();
            commanderSkill = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(TankId);
            writer.Write(TankCont);
            writer.Write(TankLevel);
            writer.Write(TankExt);
            writer.Write(ExistTime);
            writer.Write(SkinFrameType);
            writer.Write(commanderSkill);
        }
    }
}
