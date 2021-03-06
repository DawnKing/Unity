// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    /////////////////////////////////////////////////////////////
    /// 坦克皮肤进度信息
    public sealed class TankSkinChipInfo
    {
        public uint SkinId;///皮肤ID
        public uint Schedule;///进度
        public void ReadFromStream(BinaryReader reader)
        {
            SkinId = reader.ReadUInt32();
            Schedule = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SkinId);
            writer.Write(Schedule);
        }
    }
}
