// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // 战场经验数据
    public sealed class BattleExpInfo
    {
        public ulong objId;/// 对象Id
        public uint battleExpAdd;// 增加的战场经验
        public uint battleCurExp;// 当前战场经验
        public uint battleLevel;// 当前战场等级
        public void ReadFromStream(BinaryReader reader)
        {
            objId = reader.ReadUInt64();
            battleExpAdd = reader.ReadUInt32();
            battleCurExp = reader.ReadUInt32();
            battleLevel = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(objId);
            writer.Write(battleExpAdd);
            writer.Write(battleCurExp);
            writer.Write(battleLevel);
        }
    }
}