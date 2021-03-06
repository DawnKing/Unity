// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.GlobalMessage
{
    // MSGTYPE_DECLARE(MSG_ADD_GLOBAL_ROULETTE_GIFT)
    // 通知增加跨服转盘奖池的礼券
    public sealed class GlobalAddRouletteGift : IProtocol
    {
        public const short MsgType = MessageType.MSG_ADD_GLOBAL_ROULETTE_GIFT;
        public short GetMsgType { get { return MsgType; } }
        public uint GiftNum;
        
        public static void Send(uint giftNum, object className)
        {
            var packet = new GlobalAddRouletteGift
            {
                GiftNum = giftNum
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
            GiftNum = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(GiftNum);
        }
    }
}
