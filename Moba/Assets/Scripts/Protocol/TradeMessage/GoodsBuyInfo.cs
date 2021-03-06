// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TradeMessage
{
    /// 购买的结构体
    public sealed class GoodsBuyInfo
    {
        public uint goodsId;// 商品id
        public uint coinType;// 使用的货币类型 enum COIN_TYPE
        public int price;// 购买单价
        public int count;// 购买数量
        public void ReadFromStream(BinaryReader reader)
        {
            goodsId = reader.ReadUInt32();
            coinType = reader.ReadUInt32();
            price = reader.ReadInt32();
            count = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(goodsId);
            writer.Write(coinType);
            writer.Write(price);
            writer.Write(count);
        }
    }
}
