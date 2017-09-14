// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    /// 角色货币
    public sealed class CHAR_CURRENCY
    {
        public int Cash;// 点券
        public int Golden;// 银币
        public int Silver;// 礼券
        public int Honor;// 勋章
        public int icrystal;// 晶石
        public int PresentPoint;//赠送点数
        public void ReadFromStream(BinaryReader reader)
        {
            Cash = reader.ReadInt32();
            Golden = reader.ReadInt32();
            Silver = reader.ReadInt32();
            Honor = reader.ReadInt32();
            icrystal = reader.ReadInt32();
            PresentPoint = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Cash);
            writer.Write(Golden);
            writer.Write(Silver);
            writer.Write(Honor);
            writer.Write(icrystal);
            writer.Write(PresentPoint);
        }
    }
}
