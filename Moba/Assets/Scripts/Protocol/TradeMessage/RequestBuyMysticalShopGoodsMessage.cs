// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TradeMessage
{
    // 请求购买神秘商店商品
    public sealed class RequestBuyMysticalShopGoodsMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_BUY_MYSTICAL_SHOP_GOODS;
        public short GetMsgType { get { return MsgType; } }
        public const int MSBT_TANK = 1;
        public const int MSBT_GIFT = 2;
        public const int MSBT_SKIN2S = 3;
        public const int MSBT_SKIN3S = 4;
        public uint tankId;// 购买的坦克ID
        public uint buyType;// 购买类型	enum MYSTICAL_SHOP_BUY_TYPE
        
        public static void Send(uint tankId, uint buyType, object className)
        {
            var packet = new RequestBuyMysticalShopGoodsMessage
            {
                tankId = tankId,
                buyType = buyType
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
            tankId = reader.ReadUInt32();
            buyType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(tankId);
            writer.Write(buyType);
        }
    }
}