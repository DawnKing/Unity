// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CurrencyMessage
{
    public sealed class DrawDailyChargeInfo
    {
        public uint Cash;//充值档次
        public string szName;//排名第一的玩家名字
        public uint DrawCount;//领取奖励人数
        public void ReadFromStream(BinaryReader reader)
        {
            Cash = reader.ReadUInt32();
            szName = reader.ReadString();
            DrawCount = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Cash);
            writer.Write(szName);
            writer.Write(DrawCount);
        }
    }
}
