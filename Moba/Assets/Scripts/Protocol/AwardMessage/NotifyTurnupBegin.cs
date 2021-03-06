// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AwardMessage
{
    /// 通知翻牌开始
    public sealed class NotifyTurnupBegin : IProtocol
    {
        public const short MsgType = MessageType.MSG_AWARD_NOTIFY_TURNUP_BEGIN;
        public short GetMsgType { get { return MsgType; } }
        public int CountDown;// 倒计时 秒为单位
        public int CardCount;// 牌的数量
        public int TurnupCount;// 可以翻牌的次数
        public int Cash;// 点券翻牌需要的点券数量
        public uint State;// 翻牌状态 TURNUP_STATE
        
        public static void Send(int countDown, int cardCount, int turnupCount, int cash, uint state, object className)
        {
            var packet = new NotifyTurnupBegin
            {
                CountDown = countDown,
                CardCount = cardCount,
                TurnupCount = turnupCount,
                Cash = cash,
                State = state
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
            CountDown = reader.ReadInt32();
            CardCount = reader.ReadInt32();
            TurnupCount = reader.ReadInt32();
            Cash = reader.ReadInt32();
            State = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(CountDown);
            writer.Write(CardCount);
            writer.Write(TurnupCount);
            writer.Write(Cash);
            writer.Write(State);
        }
    }
}
