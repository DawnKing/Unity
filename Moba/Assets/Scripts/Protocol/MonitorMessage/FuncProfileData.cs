// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MonitorMessage
{
    public sealed class FuncProfileData
    {
        public string funcName;//函数名
        public ulong callsCnt;//调用次数
        public float callsTime;//调用时间
        public void ReadFromStream(BinaryReader reader)
        {
            funcName = reader.ReadString();
            callsCnt = reader.ReadUInt64();
            callsTime = reader.ReadSingle();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(funcName);
            writer.Write(callsCnt);
            writer.Write(callsTime);
        }
    }
}
