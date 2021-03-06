// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.GlobalMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_GLOBAL_ROULETTE_GIFT_NUM)
    // 通知当前转盘奖池的礼券数
    public sealed class NotifyGlobalRouletteGiftNum : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_GLOBAL_ROULETTE_GIFT_NUM;
        public short GetMsgType { get { return MsgType; } }
        public uint Gift;// 奖池礼券数
        
        public static void Send(uint gift, object className)
        {
            var packet = new NotifyGlobalRouletteGiftNum
            {
                Gift = gift
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
            Gift = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Gift);
        }
    }
}
