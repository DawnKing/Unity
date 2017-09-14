// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TradeMessage
{
    // 通知推荐坦克
    public sealed class NotifyRecommendTankMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_RECOMMEND_TANK;
        public short GetMsgType { get { return MsgType; } }
        public uint tankId;// 推荐的坦克ID
        public uint recommendEndTime;// 推荐结束时间
        
        public static void Send(uint tankId, uint recommendEndTime, object className)
        {
            var packet = new NotifyRecommendTankMessage
            {
                tankId = tankId,
                recommendEndTime = recommendEndTime
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
            recommendEndTime = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(tankId);
            writer.Write(recommendEndTime);
        }
    }
}