// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ActivityMessage
{
    // 对boss造成伤害
    public sealed class HarmBossInfo
    {
        public string charUuid;// 角色uuid
        public string strName;// 角色名称
        public int Harm;// 累计伤害
        public void ReadFromStream(BinaryReader reader)
        {
            charUuid = reader.ReadString();
            strName = reader.ReadString();
            Harm = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(charUuid);
            writer.Write(strName);
            writer.Write(Harm);
        }
    }
}
