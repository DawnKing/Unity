// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_CHAR_GIFT),
    // 通知玩家礼包信息
    public sealed class NotifyCharGift : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_CHAR_GIFT;
        public short GetMsgType { get { return MsgType; } }
        public GiftInfo[] giftVec;// 礼包数据
        
        public static void Send(GiftInfo[] giftVec, object className)
        {
            var packet = new NotifyCharGift
            {
                giftVec = giftVec
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
            var length1 = reader.ReadUInt16();
            giftVec = new GiftInfo[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                giftVec[i1] = new GiftInfo();
                giftVec[i1].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(giftVec == null ? 0 : giftVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                giftVec[i1].WriteToStream(writer);
            }
        }
    }
}
