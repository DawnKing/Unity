// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TradeMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_QQ_BUY_GOODS),
    // 通知qq商城购买
    public sealed class NotifyQQBuyGoods : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_QQ_BUY_GOODS;
        public short GetMsgType { get { return MsgType; } }
        public int ret;// 返回结果, 0, 表示成功; 非0,表示失败;
        public string urlParam;// 购买物品的url参数
        public string errMsg;// 如果错误，返回错误信息
        
        public static void Send(int ret, string urlParam, string errMsg, object className)
        {
            var packet = new NotifyQQBuyGoods
            {
                ret = ret,
                urlParam = urlParam,
                errMsg = errMsg
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
            ret = reader.ReadInt32();
            urlParam = reader.ReadString();
            errMsg = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(ret);
            writer.Write(urlParam);
            writer.Write(errMsg);
        }
    }
}
