// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // 火球赛可选坦克
    public sealed class NotifyFireBallCanSelTankMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_FIRE_BALL_CAN_SEL_TANK;
        public short GetMsgType { get { return MsgType; } }
        public uint[] vecTankId;// 火球赛可选坦克ID
        
        public static void Send(uint[] vecTankId, object className)
        {
            var packet = new NotifyFireBallCanSelTankMessage
            {
                vecTankId = vecTankId
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
            vecTankId = new uint[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                vecTankId[i1] = reader.ReadUInt32();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(vecTankId == null ? 0 : vecTankId.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                writer.Write(vecTankId[i1]);
            }
        }
    }
}
