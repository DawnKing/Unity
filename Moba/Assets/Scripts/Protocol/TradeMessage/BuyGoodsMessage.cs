// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TradeMessage
{
    /**
    * 购买商品
    * MSGTYPE_DECLARE(MSG_GOODS_SHOP_BUY)
    * client->gamesvr
    */
    public sealed class BuyGoodsMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_GOODS_SHOP_BUY;
        public short GetMsgType { get { return MsgType; } }
        public int type;// 购买类型
        public GoodsBuyInfo info;// 购买的商品
        public GoodsCoinVal[] coinVec;// 使用的货币
        
        public static void Send(int type, GoodsBuyInfo info, GoodsCoinVal[] coinVec, object className)
        {
            var packet = new BuyGoodsMessage
            {
                type = type,
                info = info,
                coinVec = coinVec
            };
            NetMessage.Send(packet.BuildPacket(), className);
        }
        
        public byte[] BuildPacket()
        {
            var buffer = ProtocolBuffer.Writer;
            buffer.Write(MsgType);
            buffer.Write(ProtocolBuffer.Zero);
            WriteToStream(buffer);
            return ProtocolBuffer.CacheStream.ToArray();
        }
        
        public void ReadFromStream(BinaryReader reader)
        {
            type = reader.ReadInt32();
            info = new GoodsBuyInfo();
            info.ReadFromStream(reader);
            var length3 = reader.ReadUInt16();
            coinVec = new GoodsCoinVal[length3];
            for (var i3 = 0; i3 < length3; i3++)
            {
                coinVec[i3] = new GoodsCoinVal();
                coinVec[i3].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(type);
            info.WriteToStream(writer);
            ushort count3 = (ushort)(coinVec == null ? 0 : coinVec.Length);
            writer.Write(count3);
            for(var i3 = 0; i3 < count3; i3++)
            {
                coinVec[i3].WriteToStream(writer);
            }
        }
    }
}
