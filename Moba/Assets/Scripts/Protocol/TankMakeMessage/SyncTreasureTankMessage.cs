// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMakeMessage
{
    // 通知夺宝坦克信息
    public sealed class SyncTreasureTankMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_SYNC_TREASURE_TANK;
        public short GetMsgType { get { return MsgType; } }
        public uint tankId;//夺宝坦克ID
        public uint awardTime;//奖励可领取时间
        
        public static void Send(uint tankId, uint awardTime, object className)
        {
            var packet = new SyncTreasureTankMessage
            {
                tankId = tankId,
                awardTime = awardTime
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
            awardTime = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(tankId);
            writer.Write(awardTime);
        }
    }
}
