// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_TANK_RELIVE),
    // 通知坦克复活等待时间
    public sealed class NotifyTankRelive : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_TANK_RELIVE;
        public short GetMsgType { get { return MsgType; } }
        public uint tankId;// 坦克id
        public int ReliveTime;// 复活所需时间
        
        public static void Send(uint tankId, int reliveTime, object className)
        {
            var packet = new NotifyTankRelive
            {
                tankId = tankId,
                ReliveTime = reliveTime
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
            ReliveTime = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(tankId);
            writer.Write(ReliveTime);
        }
    }
}
